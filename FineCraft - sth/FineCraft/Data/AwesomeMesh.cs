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
            vBuffer = new VertexBuffer(Static.Device, typeof(VertexAwesome), vertices.Length, BufferUsage.WriteOnly);
            vBuffer.SetData(vertices);
        }

        VertexBuffer vBuffer;
        int primitiveCount;

        public void Draw(Matrix m)
        {
            Static.Effect.WMatrix = m;
            Static.Effect.Apply3D();
            Static.Device.SetVertexBuffer(vBuffer);
            Static.Device.DrawPrimitives(PrimitiveType.TriangleList, 0, primitiveCount);
        }
        public void Draw(WorldOrientation o)
        {
            Draw(o.World);
        }
    }
}
