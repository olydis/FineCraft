using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Data;
using FineCraft.RenderEngine;

namespace FineCraft.Network.PacketTypes
{
    public class PObjectTransfer : AwesomeSerializable
    {
        public string ID;
        //public IndependentObject Object;

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            writer.Write(ID);
            //Object.Serialize(writer);
        }
        public override void Deserialize(System.IO.BinaryReader reader)
        {
            ID = reader.ReadString();
            //Object.Deserialize(reader);
        }
    }
}
