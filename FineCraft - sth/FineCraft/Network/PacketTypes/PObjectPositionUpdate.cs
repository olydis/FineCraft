using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Data;

namespace FineCraft.Network.PacketTypes
{
    public class PObjectPositionUpdate : AwesomeSerializable
    {
        public WorldOrientation Orientation = new WorldOrientation();
        public string ID;

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            writer.Write(ID);
            Orientation.Serialize(writer);
        }
        public override void Deserialize(System.IO.BinaryReader reader)
        {
            ID = reader.ReadString();
            Orientation.Deserialize(reader);
        }
    }
}
