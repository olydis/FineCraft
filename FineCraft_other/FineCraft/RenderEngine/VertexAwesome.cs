using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FineCraft.RenderEngine
{
    public struct VertexAwesome
    {
        public Vector3 Normal;
        public Vector3 Position;
        public Vector2 TextureCoordinate;
        public uint Color;
        public static VertexElement[] VertexElements
        {
            get
            {
                return new VertexElement[]
                {
                    new VertexElement(0, 0, VertexElementFormat.Vector3, VertexElementMethod.Default, VertexElementUsage.Normal,0),
                    new VertexElement(0, 12, VertexElementFormat.Vector3, VertexElementMethod.Default, VertexElementUsage.Position,0),
                    new VertexElement(0, 24, VertexElementFormat.Vector2, VertexElementMethod.Default, VertexElementUsage.TextureCoordinate,0),
                    new VertexElement(0, 32, VertexElementFormat.Color, VertexElementMethod.Default, VertexElementUsage.Color,0),
                };
            }
        }
        public VertexAwesome(byte color, Vector3 position, Vector3 normal, Vector2 textureCoordinate)
        {
            this.Normal = normal;
            this.Position = position;
            this.TextureCoordinate = textureCoordinate;
            this.Color = new Color(color, color, color).PackedValue;
        }
        public static int SizeInBytes { get { return 36; } }
    }
}
