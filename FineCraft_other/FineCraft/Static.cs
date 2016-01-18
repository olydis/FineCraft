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
        public static void InitGame(Control renderTarget, string ip, string username, string password)
        {
            //PREPARE PHASE
            //DataProvider
            DataProvider = new MultiPlayerDataProvider(() =>
            {
                TcpClient tc = new TcpClient();
                tc.Connect(ip, 8080);
                return tc;
            }, username, "joch");

            //UserData: DataProvider
            UserData = DataProvider.Login();

            //RenderTarget
            RenderTarget = renderTarget;
            
            //Window
            Window = renderTarget.TopLevelControl as Form;

            //SoundManager: Window
            SoundManager.PlayForever();

            //Device: RenderTarget
            Device = Renderer.CreateDevice();

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
