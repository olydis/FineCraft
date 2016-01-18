using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.HybridData;
using FineCraft.Data;

namespace FineCraft.Network.PacketTypes
{
    public class PChunkUpdate : AwesomeSerializable
    {
        public uint NewId;
        public WorldPosition Position = new WorldPosition();
        public uint X { get { return Position.X; } }
        public uint Y { get { return Position.Y; } }
        public uint Z { get { return Position.Z; } }

        public override string ToString()
        {
            return Position + " = " + NewId;
        }

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            writer.Write(NewId);
            Position.Serialize(writer);
        }

        public override void Deserialize(System.IO.BinaryReader reader)
        {
            NewId = reader.ReadUInt32();
            Position.Deserialize(reader);
        }
    }
}
