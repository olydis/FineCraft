using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using FineCraft.Network;
using FineCraft.HybridData;
using FineCraft.Network.PacketTypes;
using FineCraft.Data;
using FineCraft;
using System.Diagnostics;
using FineCraft.DynamicObject;

namespace Server
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            service = new Service(this);
            clientList = new CDictionary<NetworkClient, UserData>();
            listener = new TcpListener(IPAddress.Any, 8080);//0xBEAF);
            physics = new PhysicsManager(this);
        }
        TcpListener listener;
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            listener.Start();
            listener.BeginAcceptTcpClient(client,null);
            updateOverview.Start();
        }

        PhysicsManager physics;
        Service service;

        #region Client handling

        CDictionary<NetworkClient, UserData> clientList;
        bool isLoggedIn(NetworkClient nc)
        {
            return clientList.ContainsKey(nc) && clientList[nc] != null;
        }

        void client(IAsyncResult iar)
        {
            NetworkClient nc = new NetworkClient(() => listener.EndAcceptTcpClient(iar));
            nc.Register<PLoginRequest>(pLogin);
            nc.Register<PChunkRegister>(pChunkReg);
            nc.Register<PChunkUnregister>(pChunkUnreg);
            nc.Register<PChunkUpdate>(pChunkUpdate);
            nc.Register<PMyOrientationUpdate>(pUserPosSync);
            nc.Register<PChatLine>(pChatLine);
            nc.Register<DynamicBase>(pDynamicObject);
            nc.Run();

            clientList.Add(nc, new UserData());
            listener.BeginAcceptTcpClient(client, null);
        }
        void pLogin(NetworkClient nc, PLoginRequest request)
        {
            var entry = checkUserPass(request.Username, request.Password);

            if (entry == null)
            {
                clientList.Remove(nc);
                nc.Send(new PLoginResponse { Items = null });
            }
            else
            {
                uint id = entry.ID;
                clientList[nc] = entry;
                nc.ConnectionLost += nec =>
                {
                    HybridObject.UnregisterUser(id);
                    clientList[nec].Useless(id);
                    clientList.Remove(nec);
                };
                nc.Send(entry.Data);
                nc.Send(SettingsSingleton.RegisterSettings(id));
            }
        }
        void pChunkReg(NetworkClient nc, PChunkRegister chunk)
        {
            //Stopwatch sw = Stopwatch.StartNew();
            if (!isLoggedIn(nc))
                throw new Exception("Not logged in.");

            nc.Send(new PChunkTransfer
            {
                Chunk = regChunk(clientList[nc].ID, chunk.Position)
            });
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds.ToString());
        }
        void pChunkUnreg(NetworkClient nc, PChunkUnregister chunk)
        {
            if (!isLoggedIn(nc))
                throw new Exception("Not logged in.");

            if(chunk != null)
            unregChunk(clientList[nc].ID, chunk.Position);
        }
        void pChunkUpdate(NetworkClient nc, PChunkUpdate chunk)
        {
            if (!isLoggedIn(nc))
                throw new Exception("Not logged in.");

            userSetCell(clientList[nc].ID, chunk.Position, chunk.NewId);
        }
        void pUserPosSync(NetworkClient nc, PMyOrientationUpdate u)
        {
            if (!isLoggedIn(nc))
                throw new Exception("Not logged in.");

            clientList[nc].Data.Orientation = u.Orientation;
            clientList[nc].MakeDirty();
        }
        void pChatLine(NetworkClient nc, PChatLine u)
        {
            if (!isLoggedIn(nc))
                throw new Exception("Not logged in.");

            string nick = clientList[nc].Username;
            foreach (var node in clientList.AsEnumerable)
                if (node.Key != nc)
                    node.Key.Send(new PChatLine
                    {
                        Nick = nick,
                        Message = u.Message
                    });
        }
        void pDynamicObject(NetworkClient nc, DynamicBase u)
        {
            if (!isLoggedIn(nc))
                throw new Exception("Not logged in.");

            var ids = OctTree.GetTree(u.Orientation.Position.ChunkPosition).WhoKnows();
            foreach (var node in clientList.AsEnumerable)
                if (node.Key != nc && ids.Contains(node.Value.ID))
                {
                    node.Key.Send(u);
                    Console.WriteLine("sent to " + node.Value.Username);
                }
        }

        #endregion

        public void SendBroadcast(AwesomeSerializable packet)
        {
            if (packet != null)
                foreach (var node in clientList.Keys)
                    node.Send(packet);
        }

        UserData checkUserPass(string username, string password)
        {
            return UserData.Login(username, password, true);
        }
        Chunk regChunk(uint userid, WorldPosition position)
        {
            return OctTree.GetTree(position, userid).GetChunk();
        }
        void unregChunk(uint userid, WorldPosition position)
        {
            OctTree.GetTree(position).Useless(userid);
        }
        void userSetCell(uint userid, WorldPosition position, uint value)
        {
            physics.Update(position);
            var ids = OctTree.GetTree(position.ChunkPosition).Set(position.X, position.Y, position.Z, value).ToList();
            foreach (var node in clientList.AsEnumerable)
                if (node.Value.ID != userid && ids.Contains(node.Value.ID))
                    node.Key.Send(new PChunkUpdate
                    {
                        NewId = value,
                        Position = position
                    });
        }
        public void ServerSetCell(WorldPosition position, uint value)
        {
            physics.Update(position);
            var ids = OctTree.GetTree(position.ChunkPosition).Set(position.X, position.Y, position.Z, value).ToList();
            foreach (var node in clientList.AsEnumerable)
                if (ids.Contains(node.Value.ID))
                    node.Key.Send(new PChunkUpdate
                    {
                        NewId = value,
                        Position = position
                    });
        }

        private void updateOverview_Tick(object sender, EventArgs e)
        {
            var settings = SettingsSingleton.TryGetSettings();
            Text = settings == null ? "" : settings.s.dayTime.ToString();

            var loaded = HybridObject.GetLoaded().ToList();
            label1.Text =
                loaded.Count + " objects loaded:\n" + 
                string.Join("\n",
                    loaded
                        .Select(ho => ho.LifeCount + " - " + ho.Key)
                        .ToArray());
        }
    }
}
