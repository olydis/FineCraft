using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.RenderEngine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FineCraft.Data
{
    public class AwesomeMesh
    {
        public AwesomeMesh(VertexAwesome[] vertices)
        {
            primitiveCount = vertices.Length / 3;
            vBuffer = new VertexBuffer(Static.Device, vertices.Length * VertexAwesome.SizeInBytes, BufferUsage.WriteOnly);
            vBuffer.SetData(vertices);
        }

        VertexBuffer vBuffer;
        int primitiveCount;

        public void Draw(Matrix m)
        {
            Static.Effect.WMatrix = m;
            Static.Effect.BeginPass3D();
            Static.Device.Vertices[0].SetSource(vBuffer, 0, VertexAwesome.SizeInBytes);
            Static.Device.DrawPrimitives(PrimitiveType.TriangleList, 0, primitiveCount);
            Static.Effect.EndPass3D();
        }
        public void Draw(WorldOrientation o)
        {
            Draw(o.World);
        }
    }
}
