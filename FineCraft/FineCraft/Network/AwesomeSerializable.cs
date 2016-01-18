using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;

namespace FineCraft.Network
{
    public abstract class AwesomeSerializable
    {
        protected static T Deser<T>(BinaryReader reader) where T : AwesomeSerializable, new()
        {
            var t = new T();
            t.Deserialize(reader);
            return t;
        }
        protected static void SerUInt32Arr(BinaryWriter writer, uint[] o)
        {
            writer.Write(o == null ? -1 : o.Length);
            if (o != null)
                foreach (var i in o)
                    writer.Write(i);
        }
        protected static uint[] DeserUInt32Arr(BinaryReader reader)
        {
            int length = reader.ReadInt32();
            if (length == -1)
                return null;
            uint[] arr = new uint[length];
            for (int i = 0; i < length; i++)
                arr[i] = reader.ReadUInt32();
            return arr;
        }
        protected static void SerByteArr(BinaryWriter writer, byte[] o)
        {
            writer.Write(o == null ? -1 : o.Length);
            if (o != null)
                writer.Write(o);
        }
        protected static byte[] DeserByteArr(BinaryReader reader)
        {
            int length = reader.ReadInt32();
            if (length == -1)
                return null;
            return reader.ReadBytes(length);
        }
        protected static void SerArr<T>(BinaryWriter writer, T[] o) where T : AwesomeSerializable
        {
            writer.Write(o == null ? -1 : o.Length);
            if (o != null)
                foreach (var i in o)
                    if (i == null)
                        writer.Write(false);
                    else
                    {
                        writer.Write(true);
                        i.Serialize(writer);
                    }
        }
        protected static T[] DeserArr<T>(BinaryReader reader) where T : AwesomeSerializable, new()
        {
            int length = reader.ReadInt32();
            if (length == -1)
                return null;
            T[] arr = new T[length];
            for (int i = 0; i < length; i++)
                if (reader.ReadBoolean())
                    arr[i] = Deser<T>(reader);
            return arr;
        }

        public abstract void Serialize(BinaryWriter writer);
        public abstract void Deserialize(BinaryReader reader);
    }
}
