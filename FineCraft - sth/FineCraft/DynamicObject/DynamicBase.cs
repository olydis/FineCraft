using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Data;
using FineCraft.Network;
using System.IO;

namespace FineCraft.DynamicObject
{
    public abstract class DynamicBase : AwesomeSerializable
    {
        public bool DontDrawMyOwn;
        DateTime LastUpdate;
        public bool Old { get { return (DateTime.Now - LastUpdate).TotalSeconds > 5; } set { LastUpdate = value ? DateTime.MinValue : DateTime.Now; } }

        public string ID { get; protected set; }
        public WorldOrientation Orientation = new WorldOrientation();

        public sealed override void Serialize(BinaryWriter writer)
        {
            writer.Write(ID);
            Orientation.Serialize(writer);
            SerializeSub(writer);
        }
        public sealed override void Deserialize(BinaryReader reader)
        {
            ID = reader.ReadString();
            Orientation.Deserialize(reader);
            DeserializeSub(reader);
            DontDrawMyOwn = false;
        }

        protected abstract void SerializeSub(BinaryWriter writer);
        protected abstract void DeserializeSub(BinaryReader reader);
        public abstract void Render();
    }
}
