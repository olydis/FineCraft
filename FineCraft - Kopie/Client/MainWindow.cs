using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FineCraft.RenderEngine;
using FineCraft.Network;
using System.Net.Sockets;
using FineCraft.Network.PacketTypes;
using FineCraft;
using System.Diagnostics;
using FineCraft.Data;
using Microsoft.VisualBasic;
using System.Threading;

namespace Client
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            EasyIni ini = new EasyIni("finecraft");

            //string ip = Interaction.InputBox("IP:", "", ini.Get<string>("ip", "127.0.0.1"), -1, -1);
            //string username = Interaction.InputBox("Name:", "", ini.Get<string>("name", ""), -1, -1);
            string ip = ini.Get<string>("ip", "127.0.0.1");
            string username = ini.Get<string>("name", "");

            ini.Set<string>("ip", ip);
            ini.Set<string>("name", username);
            ini.Save();

            Static.InitGame(panelRender, ip, username, "joch");
            Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Text = Process.GetCurrentProcess().PrivateMemorySize64 / (1024 * 1024) + " MB";
        }
    }
}
