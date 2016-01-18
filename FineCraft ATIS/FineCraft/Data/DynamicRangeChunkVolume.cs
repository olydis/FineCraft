using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
//using System.Drawing.Drawing2D;
using Microsoft.Xna.Framework;
using FineCraft.RenderEngine;
using System.Threading;
using System.Runtime.CompilerServices;

namespace FineCraft.Data
{
    public class DynamicRangeChunkVolume
    {
        public DynamicRangeChunkVolume(GraphicsDevice device, GameDataProvider provider)
        {
            chunkWishList = new HashSet<WorldPosition>();
            this.provider = provider;
            volume = new Chunk[16, 16, 16];
            vertexBuffers = new CDictionary<Chunk, VBuffer7>();
            this.device = device;
            this.effect = Static.Effect;
            MiniMap = new Texture2D(Static.Device, 64, 64);
            MiniMapBuffer = new Color[64 * 64];
            MiniMapLayer = new Layer(MiniMap, 1, 0.7f, LayerDock.Far, LayerDock.Far, 
                () =>
                {
                    return true;
                }
                );
            MiniMapLayer.Push(new LayerCell
            {
                SourceTexture = new Rectangle(0, 0, 64, 64), 
                DestinationScreen = new Rectangle(-270, -270, 256, 256)
            });

            redrawWorker = new Timer(doRedraw);
            redrawWorker.Change(50, 50);

            hoverBoxMesh = HelpfulStuff.getCube(0.51f, GraphicsHelper.TextureCoord(36));
        }

        AwesomeMesh hoverBoxMesh;

        public Layer MiniMapLayer;
        public Texture2D MiniMap;
        Color[] MiniMapBuffer;

        int iter = 0;
        public void UpdateMinimap()
        {
            return;

            iter++; 
            if (iter % 2 != 0) return;

            for (uint y = 0; y < 64; y++)
                for (uint x = 0; x < 64; x++)
                    MiniMapBuffer[y * 64 + x] = BlockTypes.FromID(ReadValue(this.x + x - 32, this.y + y - 32, z - 3)).Schematic;
            MiniMap.SetData<Color>(MiniMapBuffer);
        } 

        public int Vertices { get; private set; }

        GameDataProvider provider;
        Chunk[, ,] volume;
        CDictionary<Chunk, VBuffer7> vertexBuffers;
        void FreeVertexBuffers(Chunk vol)
        {
            //if (vertexBuffers.ContainsKey(vol) && vertexBuffers[vol] != null)
            //    vertexBuffers[vol].Dispose();
        }

        GraphicsDevice device;
        AwesomeEffect effect;

        public uint x, y, z;
        uint chunkX, chunkY, chunkZ;

        HashSet<WorldPosition> chunkWishList;
        public void WishSomething(ref int toDo)
        {
            lock (chunkWishList)
            {
                var sorted = chunkWishList.OrderBy(wp => wp.FastDistance(x, y, z)).Take(toDo);
                foreach (var wp in sorted)
                {
                    if (!WorldPosition.Same(volume[coordToIndex(wp.X), coordToIndex(wp.Y), coordToIndex(wp.Z)].Position, wp))
                    {
                        chunkWishList.Remove(wp);
                        continue;
                    }

                    toDo--;
                    chunkWishList.Remove(wp);
                    provider.RegisterChunk(wp);

                    if (toDo == 0)
                        return;
                }
            }
        }

        uint abs(uint i)
        {
            return i > 0x80000000 ? (uint)-i : i;
        }
        uint distance(uint a, uint b)
        {
            return abs(a - b);
        }
        bool visible(uint chunkX, uint chunkY, uint chunkZ)
        {
            if (distance(chunkX, this.chunkX) > 7 * 16)
                return false;
            if (distance(chunkY, this.chunkY) > 7 * 16)
                return false;
            if (distance(chunkZ, this.chunkZ) > 7 * 16)
                return false;
            return true;
        }
        uint coordToChunkCoord(uint x) 
        {
            return x & 0xFFFFFFF0;
        }
        uint coordToIndex(uint x)
        {
            return (x >> 4) & 0xF;
        }
        public void UpdatePositionFast(WorldPosition pos)
        {
            x = pos.X;
            y = pos.Y;
            z = pos.Z;
        }
        public void UpdatePosition()
        {
            chunkX = coordToChunkCoord(x);
            chunkY = coordToChunkCoord(y);
            chunkZ = coordToChunkCoord(z);

            UpdateMinimap();

            Chunk old;
            for (uint zz = unchecked((uint)-3); zz != 4; zz++)
                for (uint xx = unchecked((uint)-3); xx != 4; xx++)
                    for (uint yy = unchecked((uint)-3); yy != 4; yy++)
                    {
                        old = volume[coordToIndex(chunkX + 16 * xx), coordToIndex(chunkY + 16 * yy), coordToIndex(chunkZ + 16 * zz)];
                        if (old == null || old.X != chunkX + 16 * xx || old.Y != chunkY + 16 * yy || old.Z != chunkZ + 16 * zz)
                        {
                            if (old != null)
                            {
                                lock (vertexBuffers)
                                {
                                    FreeVertexBuffers(old);
                                    vertexBuffers.Remove(old);
                                }
                                provider.UnregisterChunk(old.Position);
                            }
                            var wp =
                                new WorldPosition
                                {
                                    X = chunkX + 16 * xx,
                                    Y = chunkY + 16 * yy,
                                    Z = chunkZ + 16 * zz
                                };
                            volume[coordToIndex(chunkX + 16 * xx), coordToIndex(chunkY + 16 * yy), coordToIndex(chunkZ + 16 * zz)] = new Chunk
                            {
                                Value = 0,
                                Data = null,
                                Position = wp
                            };
                            //int dist = Math.Abs((int)zz) + Math.Abs((int)yy) + Math.Abs((int)xx);
                            lock (chunkWishList)
                                chunkWishList.Add(wp);
                        }
                    }
        }
        public void InsertChunk(Chunk c)
        {
            uint indexX = coordToIndex(c.X);
            uint indexY = coordToIndex(c.Y);
            uint indexZ = coordToIndex(c.Z);
            if (volume[indexX, indexY, indexZ] != null && !WorldPosition.Same(volume[indexX, indexY, indexZ].Position, c.Position))
                return;
            c.AssignVolume(this);
            vertexBuffers.Add(volume[indexX, indexY, indexZ] = c, null);
            RedrawWithSurrounding(indexX, indexY, indexZ);
        }
        public void UpdateChunk(uint x, uint y, uint z, uint value)
        {
            Chunk c = volume[coordToIndex(x), coordToIndex(y), coordToIndex(z)];
            if (c == null)
                return;
            if (coordToChunkCoord(x) != c.X)
                return;
            if(coordToChunkCoord(y) != c.Y)
                return; 
            if (coordToChunkCoord(z) != c.Z)
                return;
            c.Set(x & 0xF, y & 0xF, z & 0xF, value);
            RedrawWithSurrounding(coordToIndex(x), coordToIndex(y), coordToIndex(z));
        }
        public uint ReadValue(uint x, uint y, uint z)
        {
            Chunk c = volume[coordToIndex(x), coordToIndex(y), coordToIndex(z)];
            if (c == null)
                return 0;
            if (coordToChunkCoord(x) != c.X)
                return 0;
            if (coordToChunkCoord(y) != c.Y)
                return 0;
            if (coordToChunkCoord(z) != c.Z)
                return 0;
            return c.Get(x & 0xF, y & 0xF, z & 0xF);
        }

        HashSet<Chunk> redrawTasks = new HashSet<Chunk>();
        Timer redrawWorker;
        void doRedraw(object _)
        {
            lock (redrawTasks)
            {
                lock (Static.Device.PresentationParameters)
                    foreach (var chunk in redrawTasks)
                        vertexBuffers[chunk] = chunk.ToDraw(Static.Device);
                redrawTasks.Clear();
            }
        }

        void RedrawWithSurrounding(uint chunkX, uint chunkY, uint chunkZ)
        {
            Redraw(chunkX, chunkY, chunkZ);
            Redraw(chunkX, chunkY, chunkZ - 1);
            Redraw(chunkX, chunkY, chunkZ + 1);
            Redraw(chunkX, chunkY - 1, chunkZ);
            Redraw(chunkX, chunkY + 1, chunkZ);
            Redraw(chunkX - 1, chunkY, chunkZ);
            Redraw(chunkX + 1, chunkY, chunkZ);
        }
        void Redraw(uint chunkX, uint chunkY, uint chunkZ)
        {
            chunkX = chunkX & 0xF;
            chunkY = chunkY & 0xF;
            chunkZ = chunkZ & 0xF;
            var vol = volume[chunkX, chunkY, chunkZ];
            if (vol == null) return;
            lock (redrawTasks)
                redrawTasks.Add(vol);
        }

        BoundingSphere bs = new BoundingSphere(Vector3.Zero, 14);
        public void Render(BoundingFrustum frustum, WorldPosition hoverBox)
        {
            int vertices = 0;
            uint cx = x;
            uint cy = y; //cache = anti-earthquake
            uint cz = z;
            Matrix world = Matrix.Identity;
            Vector3 middle = new Vector3(8, 8, 8);
            foreach (var node in vertexBuffers.AsEnumerable)
            {
                if (node.Value == null)
                    continue;
                world.Translation = new Vector3((int)(node.Key.X - cx), (int)(node.Key.Y - cy), (int)(node.Key.Z - cz));
                bs.Center = middle + world.Translation;

                if (ContainmentType.Disjoint == frustum.Contains(bs))
                    continue;
                effect.WMatrix = world;

                device.Indices = Static.Indices;
                VBuffer7 vbuffer = node.Value;
                device.SetVertexBuffer(vbuffer.VertexBuffer);
                Static.Effect.RestartCurrentPass();
                Action<int> draw =
                    i =>
                    { 
                        if (vbuffer.Count[i] != 0)
                        {
                            device.DrawIndexedPrimitives(PrimitiveType.TriangleList, vbuffer.Offset[i], 0, vbuffer.Count[i], 0, vbuffer.Count[i] / 2);
                            vertices += vbuffer.Count[i];
                        }
                    };
                if (node.Key.Z - cz - 1 > 0x80000000) draw(0);
                if (node.Key.Z - cz + 16 < 0x80000000) draw(1);
                if (node.Key.X - cx - 1 > 0x80000000) draw(2);
                if (node.Key.X - cx + 16 < 0x80000000) draw(3);
                if (node.Key.Y - cy - 1 > 0x80000000) draw(4);
                if (node.Key.Y - cy + 16 < 0x80000000) draw(5);
                draw(6);
            }
            this.Vertices = vertices;

            //hovered box:
            if (hoverBox != null)
            {
                Static.Effect.LightDirection = Vector3.Backward;
                Static.Effect.AmbientLightColor = Color.LightGreen.ToVector4();
                hoverBoxMesh.Draw(Matrix.CreateTranslation((int)(hoverBox.X - cx), (int)(hoverBox.Y - cy), (int)(hoverBox.Z - cz)));
            }
        }
    }
}
