using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Data;
using System.Security.Cryptography;
using FineCraft.Network.PacketTypes;

namespace FineCraft.HybridData
{
    public class UserData : HybridObject
    {
        public static void RegisterUser(string username, string password)
        {
            RegisterNewObject(new UserData
            {
                ID = UnusedID,
                Data = new PLoginResponse
                {
                    Items = new ItemSlot[36]
                },
                Username = username.ToLower(),
                Password = toMd5(password)
            }, true);
        }

        public static UserData Login(string username, string password, bool autoRegisterNew)
        {
            UserData ud;
            foreach (var id in GetAvailable<UserData>())
            {
                ud = GetObject<UserData>(id);
                if (ud.Username == username.ToLower())
                {
                    autoRegisterNew = false;
                    if (ud.Password == toMd5(password))
                        return GetObject<UserData>(id, ud.ID);
                }
            }
            if (autoRegisterNew)
            {
                RegisterUser(username, password);
                return Login(username, password, false);
            }
            return null;
        }

        static uint UnusedID
        {
            get
            {
            redo:
                uint id = (uint)FastRandom.Single((int)DateTime.Now.Ticks);
                while (id == 0 || HasObject<UserData>(id.ToString()))
                    goto redo;
                return id;
            }
        }

        static string toMd5(string pwd)
        {
            var md5 = MD5.Create();
            return string.Join("", md5.ComputeHash(Encoding.ASCII.GetBytes(pwd)).Select(b => b.ToString("x2")).ToArray());
        }

        public override string Key
        {
            get
            {
                return ID.ToString("x8");
            }
        }

        public uint ID = 0;
        public string Username;
        public string Password;

        public PLoginResponse Data = new PLoginResponse();

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            writer.Write(ID);
            writer.Write(Username);
            writer.Write(Password);
            Data.Serialize(writer);
        }

        public override void Deserialize(System.IO.BinaryReader reader)
        {
            ID = reader.ReadUInt32();
            Username = reader.ReadString();
            Password = reader.ReadString();
            Data.Deserialize(reader);
        }
    }
}
