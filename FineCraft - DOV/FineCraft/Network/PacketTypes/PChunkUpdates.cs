using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.HybridData;
using FineCraft.Data;

namespace FineCraft.Network.PacketTypes
{
    public class PChunkUpdates : AwesomeSerializable
    {
        PChunkUpdate[] updates;

        public override string ToString()
        {
            return updates == null ? "" : (updates.Length + " updates.");
        }

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            AwesomeSerializable.SerArr<PChunkUpdate>(writer, updates);
        }

        public override void Deserialize(System.IO.BinaryReader reader)
        {
            updates = AwesomeSerializable.DeserArr<PChunkUpdate>(reader);
        }
    }
}
