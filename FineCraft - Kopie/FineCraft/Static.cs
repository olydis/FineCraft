using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.RenderEngine;
using Microsoft.Xna.Framework.Graphics;
using FineCraft.Data;
using System.Windows.Forms;
using FineCraft.Network.PacketTypes;
using System.Net.Sockets;
using FineCraft.DynamicObject;

namespace FineCraft
{
    public static class Static
    {
        static ushort[] indices;
        public static IndexBuffer Indices;

        public static void InitGame(Control renderTarget, string ip, string username, string password)
        {
            indices = new ushort[16384 * 6];
            for (ushort i = 0; i < 16384; i++)
            {
                indices[6 * i + 0] = (ushort)(4 * i + 0);
                indices[6 * i + 1] = (ushort)(4 * i + 1);
                indices[6 * i + 2] = (ushort)(4 * i + 2);
                indices[6 * i + 3] = (ushort)(4 * i + 2);
                indices[6 * i + 4] = (ushort)(4 * i + 1);
                indices[6 * i + 5] = (ushort)(4 * i + 3);
            }

            //PREPARE PHASE
            //DataProvider
            DataProvider = new MultiPlayerDataProvider(() =>
            {
                TcpClient tc = new TcpClient();
                tc.Connect(ip, 0xBEAF);
                return tc;
            }, username, "joch");

            //UserData: DataProvider
            UserData = DataProvider.Login();

            //RenderTarget
            RenderTarget = renderTarget;

            //Window
            Window = renderTarget.TopLevelControl as Form;

            //SoundManager: Window
            //SoundManager.PlayForever();

            //Device: RenderTarget
            Device = Renderer.CreateDevice();

            var ib = new IndexBuffer(Device, indices.Length * 2, BufferUsage.WriteOnly, IndexElementSize.SixteenBits);
            ib.SetData<ushort>(indices);
            Indices = ib;

            //DPerson: Device
            DPerson.Init();

            //GraphicsHelper: Device
            GraphicsHelper.Init();

            //Effect: Device
            Effect = new AwesomeEffect();

            //Volume: Device, DataProvider, Effect
            Volume = new DynamicRangeChunkVolume(Device, DataProvider);

            //Renderer: Window, Effect, RenderTarget, Device, Volume
            Renderer = new Renderer();

            //GameManager: RenderTarget, Window, Renderer, Volume
            GameManager = new GameManager();

            //RUN PHASE
            DataProvider.Start();
            Renderer.Start();
            Paused = false;
        }

        static bool paused = true;
        public static bool Paused
        {
            get
            {
                return paused;
            }
            set
            {
                paused = value;
                InvokeOnControl(control => control.Cursor = paused ? Cursors.Default : GraphicsHelper.Convert(new System.Drawing.Bitmap(32, 32), 16, 16));
            }
        }

        public static Renderer Renderer { get; private set; }
        public static GraphicsDevice Device { get; private set; }
        public static AwesomeEffect Effect { get; private set; }
        public static DynamicRangeChunkVolume Volume { get; private set; }
        public static GameDataProvider DataProvider { get; private set; }

        public static PLoginResponse UserData { get; private set; }
        public static GameManager GameManager { get; private set; }

        public static Form Window { get; private set; }
        public static Control RenderTarget { get; private set; }
        public static void Invoke(Action a)
        {
            if (Window.InvokeRequired)
                Window.Invoke(a);
            else
                a();
        }
        public static void InvokeOnWindow(Action<Form> a)
        {
            Invoke(() => a(Window));
        }
        public static void InvokeOnControl(Action<Control> a)
        {
            Invoke(() => a(RenderTarget));
        }
    }
}
