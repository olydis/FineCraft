using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.HybridData;
using FineCraft.Data;

namespace FineCraft.Network.PacketTypes
{
    [Serializable]
    public class PChunkTransfer : AwesomeSerializable
    {
        public Chunk Chunk = new Chunk();

        public override string ToString()
        {
            return Chunk.ToString();
        }

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            Chunk.Serialize(writer);
        }

        public override void Deserialize(System.IO.BinaryReader reader)
        {
            Chunk.Deserialize(reader);
        }
    }
}
