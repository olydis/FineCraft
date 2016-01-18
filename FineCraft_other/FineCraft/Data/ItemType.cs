using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FineCraft.Data
{
    public class ItemType
    {
        public uint ID;
        public string Name;
        public string Description;
        public BlockType ConvertsToBlock { get; set; }
        public Vector2 Texture;
    }
}
