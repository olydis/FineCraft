using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Network;
using FineCraft.Data;
using FineCraft.Network.PacketTypes;
using System.Net.Sockets;
using System.Threading;
using FineCraft.DynamicObject;

namespace FineCraft
{
    public class MultiPlayerDataProvider : GameDataProvider
    {
        public MultiPlayerDataProvider(Func<TcpClient> tc, string username, string password)
        {
            nc = new NetworkClient(tc);
            nc.ConnectionLost += new Action<NetworkClient>(nc_ConnectionLost);
            req = new PLoginRequest
            {
                Username = username,
                Password = password
            };
            HelpfulStuff.RunPeriodic(flushRequests, 300);
        }
        public override PLoginResponse Login()
        {
            nc.Send(req);
            return nc.ReceiveOne<PLoginResponse>();
        }
        public override void Start()
        {
            nc.Register<PChunkTransfer>(pChunkTransfer);
            nc.Register<PChunkUpdate>(pChunkUpdate);
            nc.Register<Settings>(pSettings);
            nc.Register<PChatLine>(IncomingChatLine);
            nc.Register<DynamicBase>(DynamicChange);
            nc.Run();
        }

        PLoginRequest req = null;
        public override string Username { get { return req.Username; } }

        public override void RegisterChunk(WorldPosition pos)
        {
            nc.Send(new PChunkRegister
            {
                Position = pos
            });
        }
        public override void UnregisterChunk(WorldPosition pos)
        {
            nc.Send(new PChunkUnregister
            {
                Position = pos
            });
        }
        public override void UpdateUserPosition(WorldOrientation orientation)
        {
            nc.Send(new PMyOrientationUpdate
            {
                Orientation = orientation
            });
        }
        public override void UpdateChunk(PChunkUpdate update)
        {
            nc.Send(update);
        }
        public override void SendChatMessage(string line)
        {
            var packet = new PChatLine
            {
                Nick = "You",
                Message = line
            };
            IncomingChatLine(packet);
            nc.Send(packet);
        }
        public override void UpdateDynamicObject(DynamicBase db)
        {
            DynamicManager.Change(db);
            nc.Send(db);
        }

        #region Network

        NetworkClient nc;
        void nc_ConnectionLost(NetworkClient client)
        {
            System.Windows.Forms.MessageBox.Show("some networking shit went wrong");
            System.Windows.Forms.Application.Exit();
        //    while (!client.Reconnect()) Thread.Sleep(5000);
        //    client.Run();
        }
        void pChunkTransfer(PChunkTransfer data)
        {
            lock (this)
                maxRequests++;
            Static.Volume.InsertChunk(data.Chunk);
        }
        void pChunkUpdate(PChunkUpdate data)
        {
            Static.Volume.UpdateChunk(data.X, data.Y, data.Z, data.NewId);
        }
        void pSettings(Settings data)
        {
            Static.GameManager.settings = data;
        }
        void IncomingChatLine(PChatLine packet)
        {
            Static.GameManager.DisplayLine(packet);
        }
        void DynamicChange(DynamicBase packet)
        {
            DynamicManager.Change(packet);
        }

        #endregion

        int maxRequests = 200;
        void flushRequests()
        {
            lock (this)
                if (Static.GameManager != null && Static.Volume != null)
                    Static.Volume.WishSomething(ref maxRequests);
        }
    }
}
