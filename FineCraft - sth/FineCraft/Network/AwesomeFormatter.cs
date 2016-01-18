using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO.Compression;
using System.Diagnostics;
using System.Windows.Forms;

namespace FineCraft.Network
{
    public class AwesomeFormatter
    {
        public AwesomeSerializable Deserialize(Stream s)
        {
            if (s.CanTimeout)
                s.ReadTimeout = Timeout.Infinite;
            BinaryReader reader = new BinaryReader(s);
            Type t = Type.GetType(reader.ReadString());
            try
            {
                var o = Activator.CreateInstance(t) as AwesomeSerializable;
                o.Deserialize(reader);
                return o;
            }
            catch(TargetInvocationException e)
            {
                MessageBox.Show("Failed to create instance of " + t + ":\n" + (e.InnerException ?? e));
                throw;
            }
        }
        public void Serialize(Stream s, AwesomeSerializable o)
        {
            if (s.CanTimeout)
                s.WriteTimeout = Timeout.Infinite;
            BinaryWriter writer = new BinaryWriter(s);
            writer.Write(o.GetType().FullName);
            o.Serialize(writer);
        }
        public T DeserializeKnown<T>(Stream s) where T : AwesomeSerializable, new()
        {
            if (s.CanTimeout)
                s.ReadTimeout = Timeout.Infinite;
            BinaryReader reader = new BinaryReader(s);
            var o = new T();
            o.Deserialize(reader);
            return o;
        }
        public void SerializeKnown(Stream s, AwesomeSerializable o)
        {
            if (s.CanTimeout)
                s.WriteTimeout = Timeout.Infinite;
            BinaryWriter writer = new BinaryWriter(s);
            o.Serialize(writer);
            writer.Flush();
        }
    }
}
