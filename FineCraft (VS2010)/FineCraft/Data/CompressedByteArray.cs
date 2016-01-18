using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Network;

namespace FineCraft.Data
{
    public class CompressedByteArray : AwesomeSerializable
    {
        public byte[] Data;
        public byte Value;
        public bool IsPure { get { return Data == null; } }

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            writer.Write(Value);
            SerByteArr(writer, Data);
        }

        public override void Deserialize(System.IO.BinaryReader reader)
        {
            Value = reader.ReadByte();
            Data = DeserByteArr(reader);
        }

        public void Optimize()
        {
            if (IsPure)
                return;
            foreach (uint i in Data)
                if (i != Value)
                    return;
            Data = null;
        }

        public byte[] Exploded
        {
            get
            {
                var data = new byte[4096];
                for (int i = 0; i < 4096; i++)
                    data[i] = Value;
                return data;
            }
        }
    }
}
