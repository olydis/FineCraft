using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.HybridData;
using FineCraft.Data;

namespace FineCraft.Network.PacketTypes
{
    public class PMyOrientationUpdate : AwesomeSerializable
    {
        public WorldOrientation Orientation = new WorldOrientation();

        public override string ToString()
        {
            return Orientation.ToString();
        }

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
