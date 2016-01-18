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
using FineCraft.Network.PacketTypes;
using FineCraft.Network;
using FineCraft.RenderEngine;
using FineCraft.DynamicObject;
using System.Threading;
//using Microsoft.Xna.Framework.Input;

namespace FineCraft
{
    public class GameManager
    {
        public GameManager()
        {
            Static.Window.KeyDown += KeyDown;
            Static.Window.KeyUp += KeyUp;
            Static.Window.KeyPress += KeyPress;
            Static.Window.MouseWheel += MouseWheel;
            Static.RenderTarget.MouseDown += MouseDown;
            Static.RenderTarget.MouseUp += MouseUp;

            walk = new WalkManager(this);

            me = new DPerson(Static.DataProvider.Username);
            me.DontDrawMyOwn = true;

            HelpfulStuff.RunPeriodic(Update, () => Static.Paused ? 100 : 20);
            HelpfulStuff.RunPeriodic(Sync, 1000);
        }
        WalkManager walk;

        public WorldOrientation Orientation
        {
            get
            {
                return Static.UserData.Orientation;
            }
        }

        public Settings settings = new Settings();

        public void HandleMouseMove()
        {
            int x = Static.Renderer.MidX; 
            int y = Static.Renderer.MidY;
            var state = Microsoft.Xna.Framework.Input.Mouse.GetState();
            MouseXY(state.X - x, y - state.Y);
            Microsoft.Xna.Framework.Input.Mouse.SetPosition(x, y);
        }
        void MouseXY(int x, int y)
        {
            Orientation.rotZ = MathHelper.WrapAngle(Orientation.rotZ + x / 300f);
            Orientation.rotX = MathHelper.Clamp(Orientation.rotX + y / 300f, -MathHelper.PiOver2, MathHelper.PiOver2);
        }

        public bool HighDefinition { get; private set; }

        DPerson me;
        public void Update()
        {
            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
            if (!Static.Paused)
            {
                me.Orientation = Orientation;

                walk.Tick();
                Static.Volume.UpdatePositionFast(Orientation.Position);
            }
        }

        void Sync()
        {
            settings.Tick();
            Static.Renderer.SetDayTime(settings.dayTime);
            if (!Static.Paused)
            {
                Static.Volume.UpdatePosition();
                Static.DataProvider.UpdateUserPosition(Static.UserData.Orientation);
            }
            Static.DataProvider.UpdateDynamicObject(me);
        }

        public void DisplayLine(PChatLine line)
        {
            Static.Renderer.AddChatHistory(line.ToString());
        }

        string chatLine = "";
        public bool chat = false;
        private void KeyPress(object sender, KeyPressEventArgs er)
        {
            if (chat)
            {
                char c = er.KeyChar;
                if (c < 0x20) return;
                Static.Renderer.layerCurrentChatLine.Write(c);
                chatLine += c.ToString();
            }
        }
        private void KeyDown(object sender, KeyEventArgs er)
        {
            if (!chat)
                switch (er.KeyCode)
                {
                    case Keys.Enter:
                        Static.Renderer.layerCurrentChatLine.Reset();
                        chatLine = "";
                        chat = true;
                        break;
                    case Keys.Q:
                        materialIndex--;
                        if (materialIndex < 2) materialIndex = 2;
                        break;
                    case Keys.E:
                        materialIndex++;
                        if (materialIndex > BlockTypes.count - 1) materialIndex = BlockTypes.count - 1;
                        break;
                    case Keys.W: walk.Forward = true; break;
                    case Keys.A: walk.Left = true; break;
                    case Keys.S: walk.Backward = true; break;
                    case Keys.D: walk.Right = true; break;
                    case Keys.P: Static.Paused = !Static.Paused; break;
                    case Keys.Space: walk.Jump(); break;
                    case Keys.F: walk.flightMode = !walk.flightMode; break;
                    case Keys.G: Static.Renderer.FullScreen = !Static.Renderer.FullScreen; break;
                    case Keys.C:
                        var chit = RayTracer.FirstHit(this, rayTraceRange, Orientation.Position, Orientation.GetView());
                        WorldPosition hit = new WorldPosition();

                        Random r = new Random();
                        if (chit != null)
                            for (int ix = 0; ix < 100; ix++)
                            {
                                hit.X = chit.X + (uint)r.Next(-5, 6);
                                hit.Y = chit.Y + (uint)r.Next(-5, 6);
                                hit.Z = chit.Z + (uint)r.Next(-5, 6);
                                if (BlockTypes.FromID(GetValue(hit.X, hit.Y, hit.Z)).Removable)
                                    SetValue(hit, 1);
                            }
                        break;
                    case Keys.V:
                        Vector3 side;
                        hit = RayTracer.FirstHitWithSide(this, rayTraceRange, Orientation.Position, Orientation.GetView(), out side);
                        if (hit != null)
                        {
                            hit.X = (uint)(hit.X + (int)side.X);
                            hit.Y = (uint)(hit.Y + (int)side.Y);
                            hit.Z = (uint)(hit.Z + (int)side.Z);
                            if (BlockTypes.FromID(GetValue(hit.X, hit.Y, hit.Z)).Placeable)
                                SetValue(hit, materialIndex);
                        }
                        break;
                    case Keys.R:
                        Orientation.Goto(new WorldPosition());
                        break;
                    case Keys.M:
                        SoundManager.Mute = !SoundManager.Mute;
                        break;
                    case Keys.F1:
                        Static.Renderer.SetFog(10000);
                        break;
                    case Keys.H:
                        HighDefinition = !HighDefinition;
                        break;
                    case Keys.F2:
                        string dir = HelpfulStuff.BaseDirectory.FullName + "\\";
                        int i = 1;
                        while(File.Exists(dir + i + ".png"))
                            i++;
                        try
                        {
                            Static.Renderer.ScreenShot.Save(dir + i + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        }
                        catch { }
                        break;
                }
            else
            {
                switch (er.KeyCode)
                {
                    case Keys.Back:
                        if (chatLine.Length != 0)
                        {
                            chatLine = chatLine.Substring(0, chatLine.Length - 1);
                            Static.Renderer.layerCurrentChatLine.Pop();
                        }
                        break;
                    case Keys.Enter:
                        if (chatLine.Trim() != "")
                            Static.DataProvider.SendChatMessage(chatLine);
                        chat = false;
                        break;
                    case Keys.Escape:
                        chat = false;
                        break;
                } 
            }
        }
        private void KeyUp(object sender, KeyEventArgs er)
        {
            if(!chat)
                switch (er.KeyCode)
                {
                    case Keys.W: walk.Forward = false; break;
                    case Keys.A: walk.Left = false; break;
                    case Keys.S: walk.Backward = false; break;
                    case Keys.D: walk.Right = false; break;
                }
        }

        uint materialIndex = 2;
        public uint CurrentMaterial { get { return materialIndex; } }

        static void swap(ref uint a, ref uint b)
        {
            uint temp = b;
            b = a;
            a = temp;
        }
        static readonly int rayTraceRange = 100;
        Vector3 side;
        WorldPosition startPos;
        bool draggingLeft = false;
        bool dragging = false;
        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!dragging)
                {
                    startPos = RayTracer.FirstHit(this, rayTraceRange, Orientation.Position, Orientation.GetView());
                    if (startPos != null)
                    {
                        dragging = true;
                        draggingLeft = true;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (!dragging)
                {
                    startPos = RayTracer.FirstHitWithSide(this, rayTraceRange, Orientation.Position, Orientation.GetView(), out side);
                    if (startPos != null)
                    {
                        dragging = true;
                        draggingLeft = false;
                    }
                }
            }
            else if (e.Button == MouseButtons.Middle)
            {
                var hit = RayTracer.FirstHit(this, rayTraceRange, Orientation.Position, Orientation.GetView());
                if (hit != null)
                {
                    int count = 0;
                    while (BlockTypes.FromID(GetValue(hit.X, hit.Y, hit.Z)).Blocking != BlockingType.Free)
                    {
                        hit.Z++;
                        count++;
                        if (count == 100)
                            return;
                    }
                    Orientation.Goto(hit);
                }
            }
        }
        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                dragging = false;
                WorldPosition endPos = RayTracer.FirstHit(this, rayTraceRange, Orientation.Position, Orientation.GetView());
                WorldPosition startPos = this.startPos.Clone;
                if (draggingLeft)
                {
                    if (endPos == null) endPos = startPos;
                    if (endPos.X - startPos.X > 0x80000000)swap(ref endPos.X, ref startPos.X);
                    if (endPos.Y - startPos.Y > 0x80000000)swap(ref endPos.Y, ref startPos.Y);
                    if (endPos.Z - startPos.Z > 0x80000000)swap(ref endPos.Z, ref startPos.Z);
                    HelpfulStuff.Run(() =>
                        {
                            for (uint x = startPos.X; x <= endPos.X; x++)
                                for (uint y = startPos.Y; y <= endPos.Y; y++)
                                    for (uint z = startPos.Z; z <= endPos.Z; z++)
                                        if (BlockTypes.FromID(GetValue(x, y, z)).Removable)
                                            SetValue(new WorldPosition
                                                {
                                                    X = x,
                                                    Y = y,
                                                    Z = z
                                                }, 1);
                        });
                }
                else
                {
                    if (endPos == null) endPos = startPos;
                    if (WorldPosition.Same(endPos, startPos))
                    {
                        startPos = endPos;
                        startPos.X = (uint)(startPos.X + (int)side.X);
                        startPos.Y = (uint)(startPos.Y + (int)side.Y);
                        startPos.Z = (uint)(startPos.Z + (int)side.Z);
                    }
                    if (endPos.X - startPos.X > 0x80000000)swap(ref endPos.X, ref startPos.X);
                    if (endPos.Y - startPos.Y > 0x80000000)swap(ref endPos.Y, ref startPos.Y);
                    if (endPos.Z - startPos.Z > 0x80000000)swap(ref endPos.Z, ref startPos.Z);
                    HelpfulStuff.Run(() =>
                        {
                            for (uint x = startPos.X; x <= endPos.X; x++)
                                for (uint y = startPos.Y; y <= endPos.Y; y++)
                                    for (uint z = startPos.Z; z <= endPos.Z; z++)
                                        if (BlockTypes.FromID(GetValue(x, y, z)).Placeable)
                                            SetValue(new WorldPosition
                                                {
                                                    X = x,
                                                    Y = y,
                                                    Z = z
                                                }, materialIndex);
                        });
                }
            }
        }
        private void MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                materialIndex++;
            else
                materialIndex--;
            if (materialIndex < 2) materialIndex = 2;
            if (materialIndex > BlockTypes.count - 1) materialIndex = BlockTypes.count - 1;
        }

        public void SetValue(WorldPosition pos, uint value)
        {
            Static.Volume.UpdateChunk(pos.X, pos.Y, pos.Z, value);
            Static.DataProvider.UpdateChunk(new PChunkUpdate
            {
                Position = pos,
                NewId = value
            });
        }
        public uint GetValue(uint x, uint y, uint z)
        {
            return Static.Volume.ReadValue(x, y, z);
        }
        public uint GetValue(WorldPosition pos)
        {
            return Static.Volume.ReadValue(pos.X, pos.Y, pos.Z);
        }
    }
}
