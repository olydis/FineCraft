using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Network;
using System.IO;

namespace FineCraft.Data
{
    public class Settings : AwesomeSerializable
    {
        //static
        public byte jumpHeight = 3;
        //dynamic
        public ushort dayTime = 0;

        public override void Serialize(BinaryWriter writer)
        {
            writer.Write(jumpHeight);
            writer.Write(dayTime);
        }

        public override void Deserialize(BinaryReader reader)
        {
            jumpHeight = reader.ReadByte();
            dayTime = reader.ReadUInt16();
        }

        public void Tick()
        {
            dayTime += 73;
        }
    }
}
