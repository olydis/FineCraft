using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Data;
using FineCraft.Network.PacketTypes;
using FineCraft.DynamicObject;

namespace FineCraft
{
    public abstract class GameDataProvider
    {
        public abstract PLoginResponse Login();
        public abstract void Start();
        public abstract void RegisterChunk(WorldPosition pos);
        public abstract void UnregisterChunk(WorldPosition pos);
        public abstract void UpdateUserPosition(WorldOrientation orientation);
        public abstract void UpdateChunk(PChunkUpdate update);
        public abstract void SendChatMessage(string line);
        public abstract void UpdateDynamicObject(DynamicBase db);
        public abstract string Username { get; }
    }
}
