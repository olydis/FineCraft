using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Data;

namespace FineCraft.Network.PacketTypes
{
    public class PChunkRegister : AwesomeSerializable
    {
        public WorldPosition Position = new WorldPosition();
        public uint X { get { return Position.X; } }
        public uint Y { get { return Position.Y; } }
        public uint Z { get { return Position.Z; } }

        public override string ToString()
        {
            return Position.ToString();
        }

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            Position.Serialize(writer);
        }

        public override void Deserialize(System.IO.BinaryReader reader)
        {
            Position.Deserialize(reader);
        }
    }
}
