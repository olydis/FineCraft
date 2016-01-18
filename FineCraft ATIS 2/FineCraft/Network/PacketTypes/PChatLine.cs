using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Data;

namespace FineCraft.Network.PacketTypes
{
    public class PChatLine : AwesomeSerializable
    {
        public string Message;
        public string Nick;

        public override string ToString()
        {
            return Nick + ": " + Message;
        }

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            writer.Write(Nick);
            writer.Write(Message);
        }

        public override void Deserialize(System.IO.BinaryReader reader)
        {
            Nick = reader.ReadString();
            Message = reader.ReadString();
        }
    }
}
