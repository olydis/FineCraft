using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FineCraft.RenderEngine;
using Microsoft.Xna.Framework.Graphics;

namespace FineCraft.Data
{
    public class BlockType
    {
        public uint ID;
        public string Name;
        public string Description;

        public BlockingType Blocking;
        public bool Placeable
        {
            get
            {
                if (Blocking == BlockingType.Hard)
                    return false;
                if (IsCube && !IsEmpty)
                    return false;
                return true;
            }
        }

        public bool Emitting
        {
            get
            {
                return Emissive.R + Emissive.G + Emissive.B != 0;
            }
        }

        public Color Emissive;

        public bool Removable;
        public Color Schematic;
        public bool IsCube;

        //true
        public bool IsEmpty;
        public bool IsSolid;
        public uint Texture;

        //false
        public VertexAwesome[] Mesh;
    }
}
