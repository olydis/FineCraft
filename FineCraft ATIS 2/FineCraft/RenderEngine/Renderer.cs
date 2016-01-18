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

            //pp.BackBufferFormat = SurfaceFormat.Color;
            pp.DeviceWindowHandle = Static.RenderTarget.Handle;
            pp.DepthStencilFormat = DepthFormat.Depth24Stencil8;
            pp.IsFullScreen = false;

            //MessageBox.Show(Static.RenderTarget.Handle.ToString());

            var gd = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, pp);

            return gd;
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
        RenderTarget2D rtHigh;
        // HIGH DEF:
        const int low_size = 128;
        RenderTarget2D rtLow;
        Rectangle destinationRectangle = new Rectangle(0, 0, low_size, low_size);
        Color blendus = new Color(1f / 5, 1f / 5, 1f / 5);



        SpriteBatch sbatch = new SpriteBatch(Static.Device);

        DepthStencilState defaultDSS;
        void AdjustDevice()
        {
            if (Static.RenderTarget.Width > 0 && Static.RenderTarget.Height > 0)
                lock (pp)
                {
                    pp.BackBufferWidth = (width = Static.RenderTarget.Width) ;
                    pp.BackBufferHeight = (height = Static.RenderTarget.Height) ;
                    pp.PresentationInterval = PresentInterval.Immediate;
                    pp.DepthStencilFormat = DepthFormat.Depth24Stencil8;

                    SetFog((int)DynamicRangeChunkVolume.SIZE * 3);
                    var gd = Static.Device;

                    gd.Reset(pp);

                    gd.SamplerStates[0] = SamplerState.PointClamp;
                    gd.SamplerStates[1] = SamplerState.LinearClamp;
                    gd.SamplerStates[2] = SamplerState.PointClamp;
                    gd.SamplerStates[3] = SamplerState.LinearClamp;

                    gd.RasterizerState = RasterizerState.CullCounterClockwise;
                    gd.BlendState = BlendState.AlphaBlend;
                    gd.DepthStencilState = defaultDSS = new DepthStencilState
                    {
                        DepthBufferEnable = true,
                        DepthBufferFunction = CompareFunction.LessEqual,
                        DepthBufferWriteEnable = true
                    };

                    Func<int, int> nextPow2 = null;
                    nextPow2 = i => i == 0 ? 1 : (2 * nextPow2(i / 2));
                    rtHigh = new RenderTarget2D(Static.Device, nextPow2(Static.Device.Viewport.Width - 1), nextPow2(Static.Device.Viewport.Height - 1), true, SurfaceFormat.Color, DepthFormat.Depth24Stencil8);
                    rtLow = new RenderTarget2D(Static.Device, low_size, low_size);

                    SetDayTime(lastDaytime);
                }
        }


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
            proj = Matrix.CreateScale(1,1,1.2f) * Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver2, (float)width / height, 0.01f, distance) ;
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
                float fac = MathHelper.Clamp((float)(0.9f + Math.Cos(time)), 0.1f, 1);
                Static.Effect.LightDirection = Vector3.Transform(new Vector3(0.1f, 0.2f, 0.4f), Matrix.CreateRotationX(time));
                Static.Effect.AmbientLightColor = new Vector4(fac * 0.9f, fac * 1.0f, fac * 0.8f, 1);
               
                Matrix view = Orientation.GetView();
                viewProj = view * proj;
                frustum = new BoundingFrustum(viewProj);

                Action<RenderTarget2D, Color> renderWorld = (rt, back) =>
                {
                    Static.Device.SetRenderTarget(rt);
                    Static.Device.Clear(back);

                    Static.Effect.VPMatrix = viewProj;

                    Static.Device.RasterizerState = RasterizerState.CullCounterClockwise;
                    Static.Device.BlendState = BlendState.Opaque;
                    Static.Device.DepthStencilState = defaultDSS;
                    Static.Effect.Texture = GraphicsHelper.BasicTexture;
                    Static.Volume.Render(frustum, RayTracer.FirstHit(Static.GameManager, 10, Orientation.Position, view));

                    DynamicManager.Render();
                };

                //---START SCENE
                //try
                {
                    Static.Effect.FogColor = new Color(Color.CornflowerBlue.ToVector3() * fac);

                    Static.Effect.BeginPass3D();
                    renderWorld(Static.GameManager.HighDefinition ? rtHigh : null, Static.Effect.FogColor);
                    
                    Static.Effect.VPMatrix = Matrix.CreateScale(-1, -1, 1) * Matrix.CreateOrthographic(200, 200, 0.1f, 10000) * Matrix.CreateLookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
                    Static.Effect.WMatrix = Matrix.Identity;

                    if (Static.GameManager.HighDefinition)
                    {
                        Static.Device.SetRenderTarget(rtLow);
                        Static.Device.Clear(Color.Black);

                        sbatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque, SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullNone);
                        sbatch.Draw(rtHigh, destinationRectangle, blendus);
                        sbatch.End();
                        sbatch.Begin(SpriteSortMode.Immediate, new BlendState
                        {
                            AlphaBlendFunction = BlendFunction.Add,
                            AlphaDestinationBlend = Blend.One,
                            AlphaSourceBlend = Blend.One,
                            BlendFactor = Color.White,
                            ColorBlendFunction = BlendFunction.Add,
                            ColorDestinationBlend = Blend.One,
                            ColorSourceBlend = Blend.One,
                        }, 
                        SamplerState.LinearClamp, DepthStencilState.None, RasterizerState.CullNone);
                        destinationRectangle.Offset(-1, -1);
                        sbatch.Draw(rtHigh, destinationRectangle, blendus);
                        destinationRectangle.Offset(2, 0);
                        sbatch.Draw(rtHigh, destinationRectangle, blendus);
                        destinationRectangle.Offset(0, 2);
                        sbatch.Draw(rtHigh, destinationRectangle, blendus);
                        destinationRectangle.Offset(-2, 0);
                        sbatch.Draw(rtHigh, destinationRectangle, blendus); 
                        destinationRectangle.Offset(1, -1);
                        sbatch.End();


                        Static.Device.SetRenderTarget(null);
                        Static.Effect.SetTexture("TLow", rtLow);

                        Static.Effect.BeginPassCompose();
                        Static.Device.SetRenderTarget(null);
                        Static.Device.Clear(Color.Black);
                        Static.Effect.SetTexture("THigh", rtHigh);
                        Static.Device.DrawUserPrimitives<VertexAwesome>(PrimitiveType.TriangleStrip, new VertexAwesome[]
                        {
                            new VertexAwesome(new Vector3(-100,-100,10), Vector3.Zero, Vector2.Zero),
                            new VertexAwesome(new Vector3(100,-100,10), Vector3.Zero, Vector2.UnitX),
                            new VertexAwesome(new Vector3(-100,100,10), Vector3.Zero, Vector2.UnitY),
                            new VertexAwesome(new Vector3(100,100,10), Vector3.Zero, Vector2.One), 
                        }, 0, 2);
                    }

                    //overlays
                    Layer.InitLayerRendering();

                    //Static.Volume.MiniMapLayer.Render();
                    layerLineCross.Render();
                    layerCurrentChatLine.Render();
                    debug1.Render();
                    debug2.Render();
                    debug3.Render();
                    currentMat.Render();
                    lock (chatHistory)
                        foreach (var line in chatHistory)
                            line.Render();

                    try
                    {
                        Static.Device.Present();
                    }
                    catch { }
                }
                //catch { }
                //---END SCENE
            }
            debug3.SetText(fps + " fps (" + 1000 / (fps+1) + "ms)");
            debug2.SetText(Orientation.Position.ToString());
            debug1.SetText("Vertices: " + Static.Volume.Vertices.ToString());
            currentMat.SetText("Material: " + BlockTypes.FromID(Static.GameManager.CurrentMaterial).Name);
            fpsCounter++;
        }

        ushort lastDaytime = 0;
        public void SetDayTime(ushort daytime)
        {
            lastDaytime = 32000;// daytime; //17000 todo
        }
    }
}
