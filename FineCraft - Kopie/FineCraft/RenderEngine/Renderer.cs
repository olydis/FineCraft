using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FineCraft.Data;
using System.Reflection;
using System.IO;
using System.Threading;
using Graphics2D = System.Drawing.Graphics;
using Pen2D = System.Drawing.Pen;
using Bitmap2D = System.Drawing.Bitmap;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using FineCraft.DynamicObject;

namespace FineCraft.RenderEngine
{
    public class Renderer
    {
        static PresentationParameters pp;
        public static GraphicsDevice CreateDevice()
        {
            //init PresentationParameters
            pp = new PresentationParameters();
            pp.AutoDepthStencilFormat = DepthFormat.Depth24Stencil8;
            pp.EnableAutoDepthStencil = true;
            pp.PresentOptions = PresentOptions.DiscardDepthStencil;
            pp.RenderTargetUsage = RenderTargetUsage.DiscardContents;
            pp.SwapEffect = SwapEffect.Discard;
            pp.BackBufferFormat = SurfaceFormat.Color;

            return new GraphicsDevice(GraphicsAdapter.DefaultAdapter, DeviceType.Hardware, Static.RenderTarget.Handle, pp);
        }
        

        public Renderer()
        {
            var window = Static.Window;
            var control = Static.RenderTarget;
            window.Move += Renderer_Move;
            window.Shown += Renderer_Move;
            control.Move += Renderer_Move;
            control.SizeChanged += control_Resize;

            AdjustDevice();

            Pen2D pen = new Pen2D(System.Drawing.Color.White, 3);
            var lineCross = new Bitmap2D(40, 40);
            Graphics2D glc = Graphics2D.FromImage(lineCross);
            glc.DrawLine(pen, 20, 0, 20, 16);
            glc.DrawLine(pen, 20, 24, 20, 40);
            glc.DrawLine(pen, 0, 20, 16, 20);
            glc.DrawLine(pen, 24, 20, 40, 20);

            layerLineCross = new Layer(GraphicsHelper.Convert(lineCross, Static.Device), 1, 0.7f, LayerDock.Center, LayerDock.Center, () => true);
            layerLineCross.Push(new LayerCell
            {
                SourceTexture = new Rectangle(0, 0, 40, 40),
                DestinationScreen = new Rectangle(-18, -18, 36, 36)
            });
            layerCurrentChatLine = new TextLayer("> ", 0.7f, LayerDock.Near, LayerDock.Near, () => Static.GameManager.chat);
            layerCurrentChatLine.Translation = () => new Vector2(10, 10 + layerCurrentChatLine.Height - 30);

            chatHistory = new Queue<Layer>();
            debug1 = new TextLayer("", 0.7f, LayerDock.Near, LayerDock.Far, () => true);
            debug1.Translation = () => new Vector2(0, -30);
            debug2 = new TextLayer("", 0.7f, LayerDock.Near, LayerDock.Far, () => true);
            debug2.Translation = () => new Vector2(0, -60);
            debug3 = new TextLayer("", 0.7f, LayerDock.Near, LayerDock.Far, () => true);
            debug3.Translation = () => new Vector2(0, -90);
            currentMat = new TextLayer("", 0.7f, LayerDock.Near, LayerDock.Far, () => true);
            currentMat.Translation = () => new Vector2(0, -120);

            hoverBox = HelpfulStuff.getCube(0.51f, GraphicsHelper.TextureCoord(36));
        }
        public void Start()
        {
            HelpfulStuff.RunPeriodic(Repaint, () => Static.Paused ? 100 : 0);
            HelpfulStuff.RunPeriodic(() =>
            {
                fps = fpsCounter;
                fpsCounter = 0;
            }, 1000);
        }
        void AdjustDevice()
        {
            if (Static.RenderTarget.Width > 0 && Static.RenderTarget.Height > 0)
                lock (pp)
                {
                    pp.BackBufferWidth = (width = Static.RenderTarget.Width);
                    pp.BackBufferHeight = (height = Static.RenderTarget.Height);
                    pp.PresentationInterval = PresentInterval.Immediate;

                    SetFog(100);
                    var gd = Static.Device;
                    gd.DepthStencilBuffer = new DepthStencilBuffer(gd, width, height, DepthFormat.Depth24Stencil8);

                    gd.Reset(pp);
                    gd.VertexDeclaration = new VertexDeclaration(gd, VertexAwesome.VertexElements);

                    //gd.RenderState.SeparateAlphaBlendEnabled = true;
                    gd.RenderState.AlphaTestEnable = true;
                    gd.RenderState.SourceBlend = Blend.SourceAlpha;
                    gd.RenderState.DestinationBlend = Blend.InverseSourceAlpha;
                    gd.RenderState.AlphaSourceBlend = Blend.SourceAlpha;
                    gd.RenderState.AlphaDestinationBlend = Blend.InverseSourceAlpha;
                    gd.RenderState.StencilEnable = true;
                    gd.RenderState.AlphaFunction = CompareFunction.Greater;

                    gd.RenderState.FogEnable = true;
                    gd.RenderState.MultiSampleAntiAlias = false;
                    gd.RenderState.AlphaBlendEnable = true;

                    SetDayTime(lastDaytime);
                }
        }

        AwesomeMesh hoverBox;

        #region chat
        Layer layerLineCross;
        public TextLayer layerCurrentChatLine;
        public void AddChatHistory(string line)
        {
            lock (chatHistory)
            {
                Stopwatch sw = Stopwatch.StartNew();
                var layer = new TextLayer(line, 0.7f, LayerDock.Near, LayerDock.Near, () => sw.ElapsedMilliseconds < 5000 || Static.GameManager.chat);
                layer.Translation = () => new Vector2(10, 80 + layer.Height);
                foreach (var liner in chatHistory)
                {
                    var trans = liner.Translation() + new Vector2(0, layer.Height);
                    liner.Translation = () => trans;
                }
                chatHistory.Enqueue(layer);
                if (chatHistory.Count > 10)
                    chatHistory.Dequeue();
            }
        }
        Queue<Layer> chatHistory;
        #endregion

        public int MidX
        {
            get
            {
                return x + width / 2;
            }
        }
        public int MidY
        {
            get
            {
                return y + height / 2;
            }
        }
        public int HalfWidth
        {
            get
            {
                return width / 2;
            }
        }
        public int HalfHeight
        {
            get
            {
                return height / 2;
            }
        }

        public void SetFog(int distance)
        {
            Static.Effect.FogEnd = distance;
            proj = Matrix.CreateScale(1,1,1.5f) * Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver2, (float)width / height, 0.01f, distance) ;
        }

        void control_Resize(object sender, EventArgs e)
        {
            AdjustDevice();
        }
        void Renderer_Move(object sender, EventArgs e)
        {
            Static.InvokeOnControl(control =>
            {
                var p = control.PointToScreen(System.Drawing.Point.Empty);
                x = p.X;
                y = p.Y;
            });
        }


        int width, height;
        int x, y;

        public bool FullScreen
        {
            get
            {
                bool fs = false;
                Static.InvokeOnWindow(wnd => fs = wnd.FormBorderStyle == FormBorderStyle.None);
                return fs;
            }
            set
            {
                if (FullScreen != value)
                {
                    lock (pp)
                    {
                        Static.InvokeOnWindow(wnd =>
                        {
                            wnd.FormBorderStyle = value ? FormBorderStyle.None : FormBorderStyle.Sizable;
                            wnd.WindowState = value ? FormWindowState.Maximized : FormWindowState.Normal;
                            wnd.TopMost = value;
                        });
                        AdjustDevice();
                    }
                }
            }
        }

        Matrix proj;
        Matrix viewProj;
        BoundingFrustum frustum;

        WorldOrientation Orientation
        {
            get
            {
                return Static.GameManager.Orientation;
            }
        }

        public Bitmap2D ScreenShot
        {
            get
            {
                Bitmap2D bm = new System.Drawing.Bitmap(width, height);
                using(Graphics2D g = Graphics2D.FromImage(bm))
                    Static.InvokeOnControl(control => g.CopyFromScreen(control.PointToScreen(control.Location), System.Drawing.Point.Empty, new System.Drawing.Size(width, height)));
                return bm;
            }
        }

        TextLayer debug1;
        TextLayer debug2;
        TextLayer debug3;
        TextLayer currentMat;

        int fps = 0;
        int fpsCounter = 0;
        void Repaint()
        {
            Thread.CurrentThread.IsBackground = false;
            lock (pp)
            {
                if (!Static.Paused)
                    Static.GameManager.HandleMouseMove();

                //prepare lights
                float time = lastDaytime * MathHelper.TwoPi / 65536;
                float fac = MathHelper.Clamp((float)(0.9f + Math.Cos(time)), 0.3f, 1);
                Static.Effect.LightDirection = Vector3.Transform(new Vector3(0.1f, 0.2f, 0.4f), Matrix.CreateRotationX(time));
                Static.Effect.AmbientLightColor = new Vector4(fac * 0.9f, fac * 1.0f, fac * 0.8f, 1);


                try
                {
                    //---START SCENE
                    Static.Device.Clear(Static.Effect.FogColor = new Color(Color.CornflowerBlue.ToVector3() * fac));
                    Matrix view = Orientation.GetView();
                    Static.Effect.VPMatrix = viewProj = view * proj;
                    frustum = new BoundingFrustum(viewProj);

                    Static.Effect.Begin();

                    Static.Effect.Texture = GraphicsHelper.BasicTexture;
                    Static.Volume.Render(frustum);

                    DynamicManager.Render();

                    //hovered box:
                    var wp = RayTracer.FirstHit(Static.GameManager, 10, Orientation.Position, view);
                    if (wp != null)
                    {
                        Static.Effect.LightDirection = Vector3.Backward;
                        Static.Effect.AmbientLightColor = Color.LightGreen.ToVector4();
                        hoverBox.Draw(Matrix.CreateTranslation((int)(wp.X - Static.Volume.x), (int)(wp.Y - Static.Volume.y), (int)(wp.Z - Static.Volume.z)));
                    }

                    //overlays
                    Layer.InitLayerRendering();

                    Static.Volume.MiniMapLayer.Render();
                    layerLineCross.Render();
                    layerCurrentChatLine.Render();
                    debug1.Render();
                    debug2.Render();
                    debug3.Render();
                    currentMat.Render();
                    lock (chatHistory)
                        foreach (var line in chatHistory)
                            line.Render();

                    Static.Effect.End();
                //try
                //{
                    Static.Device.Present();
                }
                catch { }
                //---END SCENE
            }
            debug3.SetText(fps + " fps");
            debug2.SetText(Orientation.Position.ToString());
            debug1.SetText("Vertices: " + Chunk.alloc / 1024 / 1024);//Static.Volume.Vertices.ToString());
            currentMat.SetText("Material: " + BlockTypes.FromID(Static.GameManager.CurrentMaterial).Name);
            fpsCounter++;
        }

        ushort lastDaytime = 0;
        public void SetDayTime(ushort daytime)
        {
            lastDaytime = 0; //daytime; //- todo
        }
    }
}
