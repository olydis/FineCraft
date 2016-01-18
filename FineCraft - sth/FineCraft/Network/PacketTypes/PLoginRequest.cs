using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineCraft.Network.PacketTypes
{
    public class PLoginRequest : AwesomeSerializable
    {
        public string Username;
        public string Password;

        public override string ToString()
        {
            return Username;
        }

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            writer.Write(Username);
            writer.Write(Password);
        }

        public override void Deserialize(System.IO.BinaryReader reader)
        {
            Username = reader.ReadString();
            Password = reader.ReadString();
        }
    }
}
