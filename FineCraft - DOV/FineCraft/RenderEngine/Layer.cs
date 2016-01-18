using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FineCraft.RenderEngine
{
    public enum LayerDock { Near, Center, Far }
    public class Layer
    {
        public static void InitLayerRendering()
        {
            Static.Device.DepthStencilState = DepthStencilState.None;
            Static.Effect.AmbientLightColor = Color.White.ToVector4();
            Static.Effect.LightDirection = Vector3.Backward;
            DirectProjection = Matrix.CreateScale(-1, 1, 1) * Matrix.CreateOrthographic(Static.Device.Viewport.Width, Static.Device.Viewport.Height, 0.1f, 1) * Matrix.CreateLookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
        }
        static Matrix DirectProjection;

        public Layer(Texture2D textureMap, int maxCells, float depth, LayerDock xDock, LayerDock yDock, Func<bool> visible)
        {
            this.visible = visible;
            this.depth = depth;
            this.xDock = xDock;
            this.yDock = yDock;
            this.textureMap = textureMap;
            this.vertexBuffer = new VertexAwesome[6*maxCells];
            this.index = 0;
            this.Translation = () => Vector2.Zero;
        }

        Func<bool> visible;


        public Func<Vector2> Translation { get; set; }

        Texture2D textureMap;

        float depth;
        LayerDock xDock, yDock;

        VertexAwesome[] vertexBuffer;
        int index;

        public int CellCount { get { return index; } }

        Vector2[] toTexCoords(Rectangle r)
        {
            Vector2[] coords = new Vector2[4];
            coords[0] = new Vector2((float)r.Right / textureMap.Width, (float)r.Top / textureMap.Height);
            coords[1] = new Vector2((float)r.Left / textureMap.Width, (float)r.Top / textureMap.Height);
            coords[2] = new Vector2((float)r.Right / textureMap.Width, (float)r.Bottom / textureMap.Height);
            coords[3] = new Vector2((float)r.Left / textureMap.Width, (float)r.Bottom / textureMap.Height);
            return coords;
        }
        Vector3[] toScreenCoords(Rectangle r)
        {
            Vector3[] coords = new Vector3[4];
            coords[0] = new Vector3(r.Right, r.Bottom, depth);
            coords[1] = new Vector3(r.Left, r.Bottom, depth);
            coords[2] = new Vector3(r.Right, r.Top, depth);
            coords[3] = new Vector3(r.Left, r.Top, depth);
            return coords;
        }

        public void UpdateCell(int cellIndex, LayerCell cell)
        {
            var tex = toTexCoords(cell.SourceTexture);
            var screen = toScreenCoords(cell.DestinationScreen);
            cellIndex *= 6;
            vertexBuffer[cellIndex + 0].Position = screen[0];
            vertexBuffer[cellIndex + 0].TextureCoordinate = tex[0];
            vertexBuffer[cellIndex + 1].Position = screen[2];
            vertexBuffer[cellIndex + 1].TextureCoordinate = tex[2];
            vertexBuffer[cellIndex + 2].Position = screen[1];
            vertexBuffer[cellIndex + 2].TextureCoordinate = tex[1];
            vertexBuffer[cellIndex + 3].Position = screen[1];
            vertexBuffer[cellIndex + 3].TextureCoordinate = tex[1];
            vertexBuffer[cellIndex + 4].Position = screen[2];
            vertexBuffer[cellIndex + 4].TextureCoordinate = tex[2];
            vertexBuffer[cellIndex + 5].Position = screen[3];
            vertexBuffer[cellIndex + 5].TextureCoordinate = tex[3];
        }
        public int Push(LayerCell cell)
        {
            var tex = toTexCoords(cell.SourceTexture);
            var screen = toScreenCoords(cell.DestinationScreen);
            Array.Copy(new VertexAwesome[]
            {
                new VertexAwesome(255,screen[0],Vector3.UnitZ,tex[0]),
                new VertexAwesome(255,screen[2],Vector3.UnitZ,tex[2]),
                new VertexAwesome(255,screen[1],Vector3.UnitZ,tex[1]),
                new VertexAwesome(255,screen[1],Vector3.UnitZ,tex[1]),
                new VertexAwesome(255,screen[2],Vector3.UnitZ,tex[2]),
                new VertexAwesome(255,screen[3],Vector3.UnitZ,tex[3]),
            }, 0, vertexBuffer, 6 * index, 6);
            index++;
            return index - 1;
        }
        public void Pop()
        {
            if (index != 0)
                index--;
        }
        public void Reset()
        {
            index = 0;
        }

        public void Render()
        {
            if (index == 0 || !visible())
                return;
            var trans = Translation();
            Static.Effect.VPMatrix = DirectProjection;
            Static.Effect.WMatrix = Matrix.CreateTranslation(
                trans.X + (xDock == LayerDock.Center ? 0 : (xDock == LayerDock.Near ? -Static.Renderer.HalfWidth : Static.Renderer.HalfWidth)),
                trans.Y + (yDock == LayerDock.Center ? 0 : (yDock == LayerDock.Near ? -Static.Renderer.HalfHeight : Static.Renderer.HalfHeight)), 0);
            Static.Effect.Texture = textureMap;

            Static.Effect.BeginPass2D();
            Static.Device.DrawUserPrimitives(PrimitiveType.TriangleList, vertexBuffer, 0, 2 * index);
        }
    }
}
