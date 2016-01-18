using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.RenderEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FineCraft.Network;
using FineCraft.WorldGenerator;

namespace FineCraft.Data
{
    public class Chunk : AwesomeSerializable
    {
        internal WorldPosition Position = new WorldPosition();
        public uint X { get { return Position.X; } }
        public uint Y { get { return Position.Y; } }
        public uint Z { get { return Position.Z; } }
        public byte Value;
        public byte[] Data;
        public bool IsPure { get { return Data == null; } }
        public bool isUntouched;

        DynamicRangeChunkVolume parentVolume = null;
        public void AssignVolume(DynamicRangeChunkVolume parentVolume)
        {
            this.parentVolume = parentVolume;
        }

        byte[] Explode()
        {
            var data = new byte[4096];
            for (int i = 0; i < 4096; i++)
                data[i] = Value;
            return data;
        }
        public void Set(uint x, uint y, uint z, uint value)
        {
            isUntouched = false;
            if (IsPure && value != Value)
                Data = Explode();
            Data[256 * (x & 0xF) + 16 * (y & 0xF) + (z & 0xF)] = Value = (byte)value;
        }
        public uint Get(uint x, uint y, uint z)
        {
            if (IsPure)
                return Value;
            return Data[256 * (x & 0xF) + 16 * (y & 0xF) + (z & 0xF)];
        }
        public void Optimize()
        {
            if (IsPure)
                return;
            foreach (uint i in Data)
                if (i != Value)
                    return;
            Data = null;
        }

        bool IsVisibleTo(BlockType block, uint x, uint y, uint z)
        {
            if (parentVolume == null) return true;

            var id = parentVolume.ReadValue(x + this.X, y + this.Y, z + this.Z);
            if (id == block.ID)
                return false;
            return !BlockTypes.FromID(id).IsSolid;
        }
        IEnumerable<VertexAwesome> getFace(bool bothSides, Vector2 uv, byte light, Vector3 internalOffset, Matrix rotate)
        {
            Vector3 normal = Vector3.Transform(Vector3.UnitZ, rotate);
            Vector3 lu = Vector3.Transform(new Vector3(-0.5f, -0.5f, 0.5f), rotate);
            Vector3 ru = Vector3.Transform(new Vector3(0.5f, -0.5f, 0.5f), rotate);
            Vector3 ld = Vector3.Transform(new Vector3(-0.5f, 0.5f, 0.5f), rotate);
            Vector3 rd = Vector3.Transform(new Vector3(0.5f, 0.5f, 0.5f), rotate);
            yield return new VertexAwesome(light, internalOffset + lu, normal, uv);
            yield return new VertexAwesome(light, internalOffset + ld, normal, uv + GraphicsHelper.TextureYUnit);
            yield return new VertexAwesome(light, internalOffset + ru, normal, uv + GraphicsHelper.TextureXUnit);
            yield return new VertexAwesome(light, internalOffset + rd, normal, uv + GraphicsHelper.TextureYUnit + GraphicsHelper.TextureXUnit);
            //yield return new VertexAwesome(light, internalOffset + ru, normal, uv + GraphicsHelper.TextureXUnit);
            //yield return new VertexAwesome(light, internalOffset + ld, normal, uv + GraphicsHelper.TextureYUnit);
            if (bothSides)
            {
                yield return new VertexAwesome(light, internalOffset + lu, -normal, uv);
                yield return new VertexAwesome(light, internalOffset + ru, -normal, uv + GraphicsHelper.TextureXUnit);
                yield return new VertexAwesome(light, internalOffset + ld, -normal, uv + GraphicsHelper.TextureYUnit);
                yield return new VertexAwesome(light, internalOffset + rd, -normal, uv + GraphicsHelper.TextureYUnit + GraphicsHelper.TextureXUnit);
                //yield return new VertexAwesome(light, internalOffset + ld, -normal, uv + GraphicsHelper.TextureYUnit);
                //yield return new VertexAwesome(light, internalOffset + ru, -normal, uv + GraphicsHelper.TextureXUnit);
            }
        }
        public VBuffer7 ToDraw(GraphicsDevice dev)
        {
            if (IsPure && BlockTypes.FromID(Value).IsEmpty)
                return null;
            var buffer = new List<VertexAwesome>[7]
            {
                new List<VertexAwesome>(4096),
                new List<VertexAwesome>(4096),
                new List<VertexAwesome>(4096),
                new List<VertexAwesome>(4096),
                new List<VertexAwesome>(4096),
                new List<VertexAwesome>(4096),
                new List<VertexAwesome>(4096),
            };

            uint ax = 0, ay = 0, az = 0;
            // 0x00000000 = seitlich beleuchtet
            // 0x00000001 = volle Kanne (senkrecht)
            // 0xFFFFFFFF = von hinten (bitte nix)
            Func<uint, int> lightInc =
                face =>
                    face == 0 ? 8 :
                    face == 1 ? 25 : 0;
            Func<uint, int> maxDist =
                face =>
                    face == 0 ? 3 :
                    face == 1 ? 10 : 0;
            Func<uint, uint, uint, byte> getLight =
                (faceX, faceY, faceZ) =>
                {
                    return 255;
                    uint bx = ax + faceX, by = ay + faceY, bz = az + faceZ;
                    int light = 5;
                    for (uint up = 0; up < maxDist(faceX) / 2; up++, light += lightInc(faceX) * 2)
                    {
                        var block2 = BlockTypes.FromID(parentVolume.ReadValue(bx + up, by, bz));
                        if (block2.IsCube && block2.IsSolid)
                            break;
                    }
                    for (uint up = 0; up < maxDist(~faceX + 1) / 2; up++, light += lightInc(~faceX + 1) * 2)
                    {
                        var block2 = BlockTypes.FromID(parentVolume.ReadValue(bx - up, by, bz));
                        if (block2.IsCube && block2.IsSolid)
                            break;
                    }
                    for (uint up = 0; up < maxDist(faceY) / 2; up++, light += lightInc(faceY) * 2)
                    {
                        var block2 = BlockTypes.FromID(parentVolume.ReadValue(bx, by + up, bz));
                        if (block2.IsCube && block2.IsSolid)
                            break;
                    }
                    for (uint up = 0; up < maxDist(~faceY + 1) / 2; up++, light += lightInc(~faceY + 1) * 2)
                    {
                        var block2 = BlockTypes.FromID(parentVolume.ReadValue(bx, by - up, bz));
                        if (block2.IsCube && block2.IsSolid)
                            break;
                    }
                    for (uint up = 0; up < maxDist(faceZ); up++, light += lightInc(faceZ))
                    {
                        var block2 = BlockTypes.FromID(parentVolume.ReadValue(bx, by, bz + up));
                        if (block2.IsCube && block2.IsSolid)
                            break;
                    }
                    for (uint up = 0; up < maxDist(~faceZ + 1) / 4; up++, light += lightInc(~faceZ + 1) / 2)
                    {
                        var block2 = BlockTypes.FromID(parentVolume.ReadValue(bx, by, bz - up));
                        if (block2.IsCube && block2.IsSolid)
                            break;
                    }
                    if (light > 255)
                        light = 255;
                    return (byte)light;
                };

            for (uint x = 0; x < 16; x++)
                for (uint y = 0; y < 16; y++)
                    for (uint z = 0; z < 16; z++)
                    {
                        ax = x + this.X;
                        ay = y + this.Y;
                        az = z + this.Z;
                        var internalOffset = new Vector3(x, y, z);
                        var block = BlockTypes.FromID(Get(x, y, z));
                        if (block == null)
                            continue;
                        var uv = GraphicsHelper.TextureCoord(block.Texture);
                        bool bothSides = !block.IsSolid;

                        if (block.IsCube)
                        {
                            if (block.IsEmpty)
                                continue;
                            if (IsPure)
                            {
                                if (x == 0) goto doit;
                                if (x == 15) goto doit;
                                if (y == 0) goto doit;
                                if (y == 15) goto doit;
                                if (z == 0) goto doit;
                                if (z == 15) goto doit;
                                continue;
                            }
                        }
                    doit:
                        if (block.IsCube)
                        {
                            bool solid = block.IsSolid;
                            int index = solid ? 0 : 6;

                            if (IsVisibleTo(block, x, y, z + 1))
                                buffer[index].AddRange(getFace(bothSides, uv, getLight(0x00000000, 0x00000000, 0x00000001), internalOffset, Matrix.Identity));

                            if (solid) index++;
                            if (IsVisibleTo(block, x, y, z - 1))
                                buffer[index].AddRange(getFace(bothSides, uv, getLight(0x00000000, 0x00000000, 0xFFFFFFFF), internalOffset, Matrix.CreateRotationY(MathHelper.Pi)));

                            if (solid) index++;
                            if (IsVisibleTo(block, x + 1, y, z))
                                buffer[index].AddRange(getFace(bothSides, uv, getLight(0x00000001, 0x00000000, 0x00000000), internalOffset, Matrix.CreateRotationX(-MathHelper.PiOver2) * Matrix.CreateRotationZ(-MathHelper.PiOver2)));
                            
                            if (solid) index++;
                            if (IsVisibleTo(block, x - 1, y, z))
                                buffer[index].AddRange(getFace(bothSides, uv, getLight(0xFFFFFFFF, 0x00000000, 0x00000000), internalOffset, Matrix.CreateRotationX(-MathHelper.PiOver2) * Matrix.CreateRotationZ(MathHelper.PiOver2)));

                            if (solid) index++;
                            if (IsVisibleTo(block, x, y + 1, z))
                                buffer[index].AddRange(getFace(bothSides, uv, getLight(0x00000000, 0x00000001, 0x00000000), internalOffset, Matrix.CreateRotationX(-MathHelper.PiOver2)));

                            if (solid) index++;
                            if (IsVisibleTo(block, x, y - 1, z))
                                buffer[index].AddRange(getFace(bothSides, uv, getLight(0x00000000, 0xFFFFFFFF, 0x00000000), internalOffset, Matrix.CreateRotationX(-MathHelper.PiOver2) * Matrix.CreateRotationZ(MathHelper.Pi)));
                        }
                        if (block.Mesh != null)
                            buffer[6].AddRange(block.Mesh.Select(va =>
                            {
                                va.Position += internalOffset;
                                va.TextureCoordinate =
                                    new Vector2(
                                        uv.X + GraphicsHelper.TextureXUnit.X * va.TextureCoordinate.X,
                                        uv.Y + GraphicsHelper.TextureYUnit.Y * va.TextureCoordinate.Y);
                                return va;
                            }));
                    }
            int totalSize = buffer.Sum(va => va.Count);
            alloc += VertexAwesome.SizeInBytes * totalSize;
            int[] counts = new int[7];
            int[] offsets = new int[7];
            if (totalSize == 0)
                return null;
            VBuffer7 vbuffer = new VBuffer7();
            VertexBuffer vb = new VertexBuffer(dev,typeof(VertexAwesome), totalSize, BufferUsage.WriteOnly);
            int cindex = 0;
            for (int i = 0; i < 7; i++)
            {
                int count = buffer[i].Count;
                if (count != 0)
                    vb.SetData<VertexAwesome>(cindex * VertexAwesome.SizeInBytes, buffer[i].ToArray(), 0, count, VertexAwesome.SizeInBytes);
                offsets[i] = cindex;
                cindex += counts[i] = count;
            }
            vbuffer.Offset = offsets;
            vbuffer.Count = counts;
            vbuffer.VertexBuffer = vb;
            return vbuffer;
        }
        public static long alloc = 0;

        public override string ToString()
        {
            return Position.ToString();
        }

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            Position.Serialize(writer);
            writer.Write(isUntouched);
            if (!isUntouched)
            {
                writer.Write(Value);
                SerByteArr(writer, Data);
            }
        }

        public override void Deserialize(System.IO.BinaryReader reader)
        {
            Position.Deserialize(reader);
            if (!(isUntouched = reader.ReadBoolean()))
            {
                Value = reader.ReadByte();
                Data = DeserByteArr(reader);
            }
            else
            {
                Data = Generator.GenerateChunk(Position).Cast<uint>().Select(x => (byte)x).ToArray();
                Value = Data[4095];
                Optimize();
            }
        }
    }
}
