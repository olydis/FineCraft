using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.RenderEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FineCraft.Network;
using FineCraft.WorldGenerator;
using System.Windows.Forms;
using System.Diagnostics;

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

        List<WorldPosition> emittingBlocks = null;
        public List<WorldPosition> EmittingBlocks
        {
            get
            {
                if (emittingBlocks == null)
                {
                    emittingBlocks = new List<WorldPosition>();
                    int i = 0;
                    for (uint z = 0; z < 16; z++)
                        for (uint y = 0; y < 16; y++)
                            for (uint x = 0; x < 16; x++, i++)
                                if (BlockTypes.FromID(Get(x, y, z)).Emitting)
                                    emittingBlocks.Add(new WorldPosition
                                    {
                                        X = Position.X + x,
                                        Y = Position.Y + y,
                                        Z = Position.Z + z
                                    });
                }
                return emittingBlocks;
            }
        }
            
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
            emittingBlocks = null;
            isUntouched = false;
            if (IsPure)
            {
                if(value != Value)
                    Data = Explode();
            }
            else
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
        IEnumerable<VertexAwesome> getFace(bool reversed, Vector2 uv, Color light, Vector3 internalOffset, Matrix rotate)
        {
            Vector3 normal = Vector3.Transform(Vector3.UnitZ, rotate);
            Vector3 lu = Vector3.Transform(new Vector3(-0.5f, -0.5f, 0.5f), rotate);
            Vector3 ru = Vector3.Transform(new Vector3(0.5f, -0.5f, 0.5f), rotate);
            Vector3 ld = Vector3.Transform(new Vector3(-0.5f, 0.5f, 0.5f), rotate);
            Vector3 rd = Vector3.Transform(new Vector3(0.5f, 0.5f, 0.5f), rotate);
            if (reversed)
            {
                yield return new VertexAwesome(light, internalOffset + lu, -normal, uv);
                yield return new VertexAwesome(light, internalOffset + ru, -normal, uv + GraphicsHelper.TextureXUnit);
                yield return new VertexAwesome(light, internalOffset + ld, -normal, uv + GraphicsHelper.TextureYUnit);
                yield return new VertexAwesome(light, internalOffset + rd, -normal, uv + GraphicsHelper.TextureYUnit + GraphicsHelper.TextureXUnit);
            }
            else
            {
                yield return new VertexAwesome(light, internalOffset + lu, normal, uv);
                yield return new VertexAwesome(light, internalOffset + ld, normal, uv + GraphicsHelper.TextureYUnit);
                yield return new VertexAwesome(light, internalOffset + ru, normal, uv + GraphicsHelper.TextureXUnit);
                yield return new VertexAwesome(light, internalOffset + rd, normal, uv + GraphicsHelper.TextureYUnit + GraphicsHelper.TextureXUnit);
            }
        }

        uint abs(uint i)
        {
            return i > 0x80000000 ? (uint)-i : i;
        }
        uint square(uint i)
        {
            return i * i;
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

            List<WorldPosition> emissives = parentVolume.AligningEmissives(X, Y, Z);

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
            Func<uint, uint, uint, Color> getLight =
                (faceX, faceY, faceZ) =>
                {
                    uint bx = ax + faceX, by = ay + faceY, bz = az + faceZ;
                    Vector3 light = Vector3.Zero;

                    foreach (var pos in emissives)
                    {
                        uint x = pos.X - bx;
                        uint y = pos.Y - by;
                        uint z = pos.Z - bz;

                        // 0 - 225
                        uint dist = square(abs(x)) + square(abs(y)) + square(abs(z));
                        if (dist > 225)
                            dist = 225;
                        float d = (225 - dist) / 225f;
                        light += BlockTypes.FromID(parentVolume.ReadValue(pos.X, pos.Y, pos.Z)).Emissive.ToVector3() * d * d * d;
                    }

                    float max =
                        Math.Max(
                            Math.Max(light.X, light.Y),
                            Math.Max(light.Z, 1));
                    light /= max * 2;

                    return new Color(light);

                    /*int light = 5;
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
                    return new Color((byte)light, (byte)light, (byte)light);*/
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
                            {
                                int index = 0;
                                if (IsVisibleTo(block, x, y, z + 1))
                                    buffer[index].AddRange(getFace(false, uv, getLight(0x00000000, 0x00000000, 0x00000001), internalOffset, Matrix.Identity));

                                index++;
                                if (IsVisibleTo(block, x, y, z - 1))
                                    buffer[index].AddRange(getFace(false, uv, getLight(0x00000000, 0x00000000, 0xFFFFFFFF), internalOffset, Matrix.CreateRotationY(MathHelper.Pi)));

                                index++;
                                if (IsVisibleTo(block, x + 1, y, z))
                                    buffer[index].AddRange(getFace(false, uv, getLight(0x00000001, 0x00000000, 0x00000000), internalOffset, Matrix.CreateRotationX(-MathHelper.PiOver2) * Matrix.CreateRotationZ(-MathHelper.PiOver2)));

                                index++;
                                if (IsVisibleTo(block, x - 1, y, z))
                                    buffer[index].AddRange(getFace(false, uv, getLight(0xFFFFFFFF, 0x00000000, 0x00000000), internalOffset, Matrix.CreateRotationX(-MathHelper.PiOver2) * Matrix.CreateRotationZ(MathHelper.PiOver2)));

                                index++;
                                if (IsVisibleTo(block, x, y + 1, z))
                                    buffer[index].AddRange(getFace(false, uv, getLight(0x00000000, 0x00000001, 0x00000000), internalOffset, Matrix.CreateRotationX(-MathHelper.PiOver2)));

                                index++;
                                if (IsVisibleTo(block, x, y - 1, z))
                                    buffer[index].AddRange(getFace(false, uv, getLight(0x00000000, 0xFFFFFFFF, 0x00000000), internalOffset, Matrix.CreateRotationX(-MathHelper.PiOver2) * Matrix.CreateRotationZ(MathHelper.Pi)));
                            }
                            if(bothSides)
                            {
                                int index = 0;
                                if (IsVisibleTo(block, x, y, z + 1))
                                    buffer[index + 1].AddRange(getFace(true, uv, getLight(0x00000000, 0x00000000, 0x00000001), internalOffset, Matrix.Identity));

                                index++;
                                if (IsVisibleTo(block, x, y, z - 1))
                                    buffer[index - 1].AddRange(getFace(true, uv, getLight(0x00000000, 0x00000000, 0xFFFFFFFF), internalOffset, Matrix.CreateRotationY(MathHelper.Pi)));

                                index++;
                                if (IsVisibleTo(block, x + 1, y, z))
                                    buffer[index + 1].AddRange(getFace(true, uv, getLight(0x00000001, 0x00000000, 0x00000000), internalOffset, Matrix.CreateRotationX(-MathHelper.PiOver2) * Matrix.CreateRotationZ(-MathHelper.PiOver2)));

                                index++;
                                if (IsVisibleTo(block, x - 1, y, z))
                                    buffer[index - 1].AddRange(getFace(true, uv, getLight(0xFFFFFFFF, 0x00000000, 0x00000000), internalOffset, Matrix.CreateRotationX(-MathHelper.PiOver2) * Matrix.CreateRotationZ(MathHelper.PiOver2)));

                                index++;
                                if (IsVisibleTo(block, x, y + 1, z))
                                    buffer[index + 1].AddRange(getFace(true, uv, getLight(0x00000000, 0x00000001, 0x00000000), internalOffset, Matrix.CreateRotationX(-MathHelper.PiOver2)));

                                index++;
                                if (IsVisibleTo(block, x, y - 1, z))
                                    buffer[index - 1].AddRange(getFace(true, uv, getLight(0x00000000, 0xFFFFFFFF, 0x00000000), internalOffset, Matrix.CreateRotationX(-MathHelper.PiOver2) * Matrix.CreateRotationZ(MathHelper.Pi)));
                            }
                        }
                        if (block.Mesh != null)
                            buffer[6].AddRange(block.Mesh.Select(va =>
                            {
                                va.Position += internalOffset;
                                va.TextureCoordinate =
                                    new Vector2(
                                        uv.X + GraphicsHelper.TextureXUnit.X * va.TextureCoordinate.X,
                                        uv.Y + GraphicsHelper.TextureYUnit.Y * va.TextureCoordinate.Y);
                                va.Color = getLight(0x00000000, 0x00000000, 0x00000000).PackedValue;
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
            VertexBuffer vb = new VertexBuffer(dev, typeof(VertexAwesome), totalSize, BufferUsage.WriteOnly);
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

            //TODO-rem!!!wegen bis jetzt unerklärlichem Fenchel bug
            if (Position.X == 0 && Position.Y == 0 && Position.Z == 0)
            {
                MessageBox.Show("Es wurde eine defekte Datei identifiziert! Adios.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Process.GetCurrentProcess().Kill();
            }

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
