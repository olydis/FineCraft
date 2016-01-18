using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.WorldGenerator;
using FineCraft.Data;

namespace FineCraft.HybridData
{
    [Serializable]
    public class OctTree : HybridObject
    {
        public static OctTree GetTree(WorldPosition position, uint userid)
        {
            var ot = GetObject<OctTree>(position.ToString(), userid);
            if (ot == null)
            {
                ot = new OctTree(new Chunk
                {
                    Data = Generator.GenerateChunk(position).Cast<uint>().Select(x => (byte)x).ToArray(),
                    Position = position,
                    isUntouched = true
                });
                ot.chunk.Value = ot.chunk.Data[4095];
                ot.Optimize();
                RegisterNewObject(ot, false);
                return GetObject<OctTree>(ot.Key, userid);
            }
            return ot;
        }
        public static OctTree GetTree(WorldPosition position)
        {
            var ot = GetObject<OctTree>(position.ToString());
            if (ot == null)
            {
                ot = new OctTree(new Chunk
                {
                    Data = Generator.GenerateChunk(position).Cast<uint>().Select(x => (byte)x).ToArray(),
                    Position = position,
                    isUntouched = true
                }); 
                ot.chunk.Value = ot.chunk.Data[4095];
                ot.Optimize();
                RegisterNewObject(ot, false);
                return GetObject<OctTree>(ot.Key);
            }
            return ot;
        }
        public override string Key
        {
            get { return this.ToString(); }
        }

        public OctTree()
        {
            chunk = new Chunk();
        }
        OctTree(Chunk c)
        {
            chunk = c;
        }

        Chunk chunk;

        WorldPosition Position { get { return chunk.Position; } set { chunk.Position = value; } }
        public uint X { get { return Position.X; } }
        public uint Y { get { return Position.Y; } }
        public uint Z { get { return Position.Z; } }
        public bool IsPure { get { return chunk.IsPure; } }

        public uint this[uint x, uint y, uint z]
        {
            get
            {
                return Get(x, y, z);
            }
            set
            {
                Set(x, y, z, value);
            }
        }

        public Chunk GetChunk()
        {
            return chunk;
        }
        public IEnumerable<uint> Set(uint x, uint y, uint z, uint value)
        {
            chunk.Set(x, y, z, value);
            return MakeDirty();
        }
        public uint Get(uint x, uint y, uint z)
        {
            return chunk.Get(x, y, z);
        }
        public void Optimize()
        {
            chunk.Optimize();
            MakeDirty();
        }

        public override string ToString()
        {
            return Position.ToString();
        }

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            chunk.Serialize(writer);
        }

        public override void Deserialize(System.IO.BinaryReader reader)
        {
            chunk.Deserialize(reader);
        }
    }
}
