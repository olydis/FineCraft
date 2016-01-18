using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FineCraft.RenderEngine
{
    public struct VertexAwesome : IVertexType
    {
        public Vector3 Position;
        public Vector2 TextureCoordinate;
        public uint Color;
        public Vector3 Normal;
        public static VertexElement[] VertexElements
        {
            get
            {
                return new VertexElement[]
                {
                    new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position,0),
                    new VertexElement(12, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate,0),
                    new VertexElement(20, VertexElementFormat.Color, VertexElementUsage.Color,0),
                    new VertexElement(24, VertexElementFormat.Vector3, VertexElementUsage.Normal,0),
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

        public VertexDeclaration VertexDeclaration
        {
            get { return new VertexDeclaration(SizeInBytes, VertexElements); }
        }
    }
    //public struct VertexAwesome
    //{
    //    public uint Color;

    //    public HalfVector2 _TextureCoordinate;
    //    public Vector2 TextureCoordinate
    //    {
    //        get
    //        {
    //            return _TextureCoordinate.ToVector2();
    //        }
    //        set
    //        {
    //            _TextureCoordinate = new HalfVector2(value);
    //        }
    //    }

    //    public Normalized101010 _Normal;
    //    public Vector3 Normal
    //    {
    //        set
    //        {
    //            _Normal = new Normalized101010(value);
    //        }
    //    }

    //    public HalfVector4 _Position;
    //    public Vector3 Position
    //    {
    //        get
    //        {
    //            var v4 = _Position.ToVector4();
    //            return new Vector3(v4.X, v4.Y, v4.Z);
    //        }
    //        set
    //        {
    //            _Position = new HalfVector4(new Vector4(value, 0));
    //        }
    //    }


    //    public static VertexElement[] VertexElements
    //    {
    //        get
    //        {
    //            return new VertexElement[]
    //            {
    //                new VertexElement(0, 0, VertexElementFormat.Color, VertexElementMethod.Default, VertexElementUsage.Color,0),
    //                new VertexElement(0, 4, VertexElementFormat.HalfVector2, VertexElementMethod.Default, VertexElementUsage.TextureCoordinate,0),
    //                new VertexElement(0, 8, VertexElementFormat.Normalized101010, VertexElementMethod.Default, VertexElementUsage.Normal,0),
    //                new VertexElement(0, 12, VertexElementFormat.HalfVector4, VertexElementMethod.Default, VertexElementUsage.Position,0),
    //            };
    //        }
    //    }
    //    public VertexAwesome(byte color, Vector3 position, Vector3 normal, Vector2 textureCoordinate)
    //    {
    //        this._Normal = new Normalized101010(normal);
    //        this._Position = new HalfVector4(new Vector4(position, 0));
    //        this._TextureCoordinate = new HalfVector2(textureCoordinate);
    //        this.Color = new Color(color, color, color).PackedValue;
    //    }
    //    public static int SizeInBytes { get { return 16; } }
    //}
}
