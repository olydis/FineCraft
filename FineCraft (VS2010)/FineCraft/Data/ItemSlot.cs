using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Network;

namespace FineCraft.Data
{
    public class ItemSlot : AwesomeSerializable
    {
        public uint Item;
        public uint Count;

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            writer.Write(Item);
            writer.Write(Count);
        }

        public override void Deserialize(System.IO.BinaryReader reader)
        {
            Item = reader.ReadUInt32();
            Count = reader.ReadUInt32();
        }
    }
}
