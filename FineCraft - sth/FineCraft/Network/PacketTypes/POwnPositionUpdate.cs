using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Data;

namespace FineCraft.Network.PacketTypes
{
    public class POwnPositionUpdate : AwesomeSerializable
    {
        public WorldOrientation Orientation = new WorldOrientation();

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            Orientation.Serialize(writer);
        }
        public override void Deserialize(System.IO.BinaryReader reader)
        {
            Orientation.Deserialize(reader);
        }
    }
}
