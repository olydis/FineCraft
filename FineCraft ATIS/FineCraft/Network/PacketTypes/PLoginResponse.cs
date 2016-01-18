using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.HybridData;
using FineCraft.Data;

namespace FineCraft.Network.PacketTypes
{
    public class PLoginResponse : AwesomeSerializable
    {
        public WorldOrientation Orientation = new WorldOrientation();
        public ItemSlot[] Items;

        public bool Succeeded { get { return Items != null; } }
        public override string ToString()
        {
            return Succeeded ? "UserData transfer/update" : "Failed";
        }

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            Orientation.Serialize(writer);
            SerArr<ItemSlot>(writer, Items);
        }

        public override void Deserialize(System.IO.BinaryReader reader)
        {
            Orientation.Deserialize(reader);
            Items = DeserArr<ItemSlot>(reader);
        }
    }
}
