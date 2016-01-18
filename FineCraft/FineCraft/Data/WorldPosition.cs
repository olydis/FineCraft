using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Network;
using FineCraft.WorldGenerator;

namespace FineCraft.Data
{
    public class WorldPosition : AwesomeSerializable
    {
        public WorldPosition()
        {
            SetOvergroundZ();
        }
        void SetOvergroundZ()
        {
            Z = (uint)(Generator.GenerateHeight(this) + 0x80000000);
        }

        //public uint X = 0x800004fa;
        //public uint Y = 0x80001770;
        //public uint Z = 0x80000001;
        public uint X = 0x7fffffb0;
        public uint Y = 0x80000000;
        public uint Z = 0x7ffff6e0;

        public static bool Same(WorldPosition wp1, WorldPosition wp2)
        {
            if (wp1 == null || wp2 == null)
                return false;
            if (wp1.X != wp2.X)
                return false;
            if (wp1.Y != wp2.Y)
                return false;
            if (wp1.Z != wp2.Z)
                return false;
            return true;
        }

        public WorldPosition Clone
        {
            get
            {
                return new WorldPosition
                {
                    X = this.X,
                    Y = this.Y,
                    Z = this.Z
                };
            }
        }

        uint abs(uint num)
        {
            if (num > 0x80000000)
                return ~num;
            return num;
        }
        public uint FastDistance(uint x, uint y, uint z)
        {
            return abs(X + 8 - x) + abs(Y + 8 - y) + abs(Z + 8 - z) >> 2;
        }

        public WorldPosition ChunkPosition
        {
            get
            {
                return new WorldPosition
                {
                    X = this.X & 0xFFFFFFF0,
                    Y = this.Y & 0xFFFFFFF0,
                    Z = this.Z & 0xFFFFFFF0
                };
            }
        }

        public override string ToString()
        {
            return X.ToString("x8") + "_" + Y.ToString("x8") + "_" + Z.ToString("x8");
        }

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            writer.Write(X);
            writer.Write(Y);
            writer.Write(Z);
        }

        public override void Deserialize(System.IO.BinaryReader reader)
        {
            X = reader.ReadUInt32();
            Y = reader.ReadUInt32();
            Z = reader.ReadUInt32();
        }
    }
}
