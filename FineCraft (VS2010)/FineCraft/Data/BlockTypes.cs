using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FineCraft.RenderEngine;

namespace FineCraft.Data
{
    public enum BlockingType { Free, Liquid, Hard }
    public static class BlockTypes
    {
        enum CubeType { Empty, SemiTransparent, Solid }
        static BlockTypes()
        {
            blockTypes = new BlockType[256];
            nameMap = new Dictionary<string, BlockType>();
            //!!!!!!!!!!!!!!!!!!!!!!!
            //!!Reihenfolge WICHTIG!!
            //!!!!!!!!!!!!!!!!!!!!!!!
            addCube(CubeType.Empty, false, BlockingType.Hard, 0, "Nothing", "Not yet loaded");
            addCube(CubeType.Empty, true, BlockingType.Free, 0, "Air", "Nothing but air");
            addCube(CubeType.Solid, true, BlockingType.Hard, 1, "Stone", "Gray 'n' cold stone");
            addCube(CubeType.Solid, true, BlockingType.Hard, 2, "Dirt", "Brown crap");
            addCube(CubeType.SemiTransparent, true, BlockingType.Hard, 49, "Glass", "You can see through glass");
            addCustom(BlockingType.Hard, 136, GetCyl(18), "Column", "Roundy round thingy");
            addCube(CubeType.Solid, true, BlockingType.Hard, 135, "Marble", "Big time");
            addCustom(BlockingType.Free, 15, GetFold(3, 1.6f, -0.5f, 1f, Vector2.Zero), "Bush", "Green hope");
            addCube(CubeType.Solid, true, BlockingType.Hard, 0, "Grass", "Awesome", GetFold(3, 1.6f, 0.5f, 1.5f, Vector2.UnitY));
            addCustom(BlockingType.Free, 12, GetFold(3, 1.6f, -0.5f, 1f, Vector2.Zero), "Flower", "Red roses are gay");
            addCustom(BlockingType.Hard, 116, GetCyl(18), "Tree1", "Kind A");
            addCustom(BlockingType.Hard, 117, GetCyl(18), "Tree2", "Kind B");
            addCustom(BlockingType.Free, 132, GetWild(3, 5f), "Leaf1", "Kind A");
            addCustom(BlockingType.Free, 133, GetWild(3, 5f), "Leaf2", "Kind B");
            addCube(CubeType.Solid, true, BlockingType.Hard, 4, "Wood", "Get outa heee");
            addCube(CubeType.Solid, true, BlockingType.Hard, 151, "BMarble", "Big time as well");
            addCube(CubeType.SemiTransparent, false, BlockingType.Liquid, 49, "Water", "Wet stuff");
        }
        static VertexAwesome[] GetCyl(int num)
        {
            var mesh = new VertexAwesome[12 * num];
            for (int i = 0; i < num; i++)
            {
                mesh[12 * i + 7] = mesh[12 * i + 0] = new VertexAwesome(255, Vector3.Transform(new Vector3(0, 0.5f, -0.5f), Matrix.CreateRotationZ(MathHelper.TwoPi * i / num)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num)), new Vector2((float)i / num, 0));
                mesh[12 * i + 11] = mesh[12 * i + 1] = mesh[12 * i + 4] = new VertexAwesome(255, Vector3.Transform(new Vector3(0, 0.5f, 0.5f), Matrix.CreateRotationZ(MathHelper.TwoPi * i / num)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num)), new Vector2((float)i / num, 1));
                mesh[12 * i + 8] = mesh[12 * i + 3] = mesh[12 * i + 2] = new VertexAwesome(255, Vector3.Transform(new Vector3(0, 0.5f, -0.5f), Matrix.CreateRotationZ(MathHelper.TwoPi * (i + 1) / num)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * (i + 1) / num)), new Vector2((float)(i + 1) / num, 0));
                mesh[12 * i + 10] = mesh[12 * i + 5] = new VertexAwesome(255, Vector3.Transform(new Vector3(0, 0.5f, 0.5f), Matrix.CreateRotationZ(MathHelper.TwoPi * (i + 1) / num)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * (i + 1) / num)), new Vector2((float)(i + 1) / num, 1));
                mesh[12 * i + 6] = new VertexAwesome(255, new Vector3(0, 0, -0.5f), -Vector3.UnitZ, new Vector2(0.5f, 0.5f));
                mesh[12 * i + 9] = new VertexAwesome(255, new Vector3(0, 0, 0.5f), Vector3.UnitZ, new Vector2(0.5f, 0.5f));
            }
            return mesh;
        }
        static VertexAwesome[] GetFold(int num, float sideScale, float lowerZ, float upperZ, Vector2 relTex)
        {
            float rotOffset = count / 10f + 0.3f;
            VertexAwesome[] mesh = new VertexAwesome[12 * num];
            for (int i = 0; i < num; i++)
            {
                mesh[12 * i + 11] = mesh[12 * i + 0] = new VertexAwesome(255, Vector3.Transform(new Vector3(0, 0.5f * sideScale, lowerZ), Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num)), relTex + new Vector2(0, 1));
                mesh[12 * i + 10] = mesh[12 * i + 7] = mesh[12 * i + 1] = mesh[12 * i + 4] = new VertexAwesome(255, Vector3.Transform(new Vector3(0, 0.5f * sideScale, upperZ), Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num)), relTex + new Vector2(0, 0));
                mesh[12 * i + 8] = mesh[12 * i + 9] = mesh[12 * i + 3] = mesh[12 * i + 2] = new VertexAwesome(255, Vector3.Transform(new Vector3(0, 0.5f * sideScale, lowerZ), Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + MathHelper.Pi + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + MathHelper.Pi)), relTex + new Vector2(1, 1));
                mesh[12 * i + 6] = mesh[12 * i + 5] = new VertexAwesome(255, Vector3.Transform(new Vector3(0, 0.5f * sideScale, upperZ), Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + MathHelper.Pi + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + MathHelper.Pi)), relTex + new Vector2(1, 0));
            }
            return mesh;
        }
        static VertexAwesome[] GetWild(int num, float scale)
        {
            float rotOffset = count / 10f + 0.3f;
            int segment = 12 * num;
            VertexAwesome[] mesh = new VertexAwesome[3 * segment];
            for (int i = 0; i < num; i++)
            {
                mesh[12 * i + 11] = mesh[12 * i + 0] = new VertexAwesome(255, Vector3.Transform(new Vector3(0, 0.5f * scale, -0.5f * scale), Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num)), new Vector2(0, 1));
                mesh[12 * i + 10] = mesh[12 * i + 7] = mesh[12 * i + 1] = mesh[12 * i + 4] = new VertexAwesome(255, Vector3.Transform(new Vector3(0, 0.5f * scale, 0.5f * scale), Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num)), new Vector2(0, 0));
                mesh[12 * i + 8] = mesh[12 * i + 9] = mesh[12 * i + 3] = mesh[12 * i + 2] = new VertexAwesome(255, Vector3.Transform(new Vector3(0, 0.5f * scale, -0.5f * scale), Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + MathHelper.Pi + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + MathHelper.Pi)), new Vector2(1, 1));
                mesh[12 * i + 6] = mesh[12 * i + 5] = new VertexAwesome(255, Vector3.Transform(new Vector3(0, 0.5f * scale, 0.5f * scale), Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + MathHelper.Pi + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + MathHelper.Pi)), new Vector2(1, 0));
            }
            for (int i = 0; i < num; i++)
            {
                mesh[segment + 12 * i + 11] = mesh[segment + 12 * i + 0] = new VertexAwesome(255, Vector3.Transform(new Vector3(0.5f * scale, -0.5f * scale,0), Matrix.CreateRotationY(MathHelper.TwoPi * i / num + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num)), new Vector2(0, 1));
                mesh[segment + 12 * i + 10] = mesh[segment + 12 * i + 7] = mesh[segment + 12 * i + 1] = mesh[segment + 12 * i + 4] = new VertexAwesome(255, Vector3.Transform(new Vector3(0.5f * scale, 0.5f * scale, 0), Matrix.CreateRotationY(MathHelper.TwoPi * i / num + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num)), new Vector2(0, 0));
                mesh[segment + 12 * i + 8] = mesh[segment + 12 * i + 9] = mesh[segment + 12 * i + 3] = mesh[segment + 12 * i + 2] = new VertexAwesome(255, Vector3.Transform(new Vector3(0.5f * scale, -0.5f * scale, 0), Matrix.CreateRotationY(MathHelper.TwoPi * i / num + MathHelper.Pi + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + MathHelper.Pi)), new Vector2(1, 1));
                mesh[segment + 12 * i + 6] = mesh[segment + 12 * i + 5] = new VertexAwesome(255, Vector3.Transform(new Vector3(0.5f * scale, 0.5f * scale,0), Matrix.CreateRotationY(MathHelper.TwoPi * i / num + MathHelper.Pi + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + MathHelper.Pi)), new Vector2(1, 0));
            }
            for (int i = 0; i < num; i++)
            {
                mesh[2 * segment + 12 * i + 11] = mesh[2 * segment + 12 * i + 0] = new VertexAwesome(255, Vector3.Transform(new Vector3(-0.5f * scale, 0, 0.5f * scale), Matrix.CreateRotationX(MathHelper.TwoPi * i / num + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num)), new Vector2(0, 1));
                mesh[2 * segment + 12 * i + 10] = mesh[2 * segment + 12 * i + 7] = mesh[2 * segment + 12 * i + 1] = mesh[2 * segment + 12 * i + 4] = new VertexAwesome(255, Vector3.Transform(new Vector3(0.5f * scale, 0, 0.5f * scale), Matrix.CreateRotationX(MathHelper.TwoPi * i / num + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num)), new Vector2(0, 0));
                mesh[2 * segment + 12 * i + 8] = mesh[2 * segment + 12 * i + 9] = mesh[2 * segment + 12 * i + 3] = mesh[2 * segment + 12 * i + 2] = new VertexAwesome(255, Vector3.Transform(new Vector3(-0.5f * scale, 0, 0.5f * scale), Matrix.CreateRotationX(MathHelper.TwoPi * i / num + MathHelper.Pi + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + MathHelper.Pi)), new Vector2(1, 1));
                mesh[2 * segment + 12 * i + 6] = mesh[2 * segment + 12 * i + 5] = new VertexAwesome(255, Vector3.Transform(new Vector3(0.5f * scale, 0, 0.5f * scale), Matrix.CreateRotationX(MathHelper.TwoPi * i / num + MathHelper.Pi + rotOffset)), Vector3.Transform(Vector3.UnitY, Matrix.CreateRotationZ(MathHelper.TwoPi * i / num + MathHelper.Pi)), new Vector2(1, 0));
            }
            return mesh;
        }


        static void addCube(CubeType type, bool removable, BlockingType blocking, uint texture, string name, string description)
        {
            addCube(type, removable, blocking, texture, name, description, null);
        }
        static void addCube(CubeType type, bool removable, BlockingType blocking, uint texture, string name, string description, VertexAwesome[] mesh)
        {
            add(new BlockType
            {
                Name = name,
                Description = description,
                IsCube = true,
                IsEmpty = type == CubeType.Empty,
                IsSolid = type == CubeType.Solid,
                Removable = removable,
                Blocking = blocking,
                Texture = texture,
                Mesh = mesh
            });
        }
        static void addCustom(BlockingType blocking, uint texture, VertexAwesome[] mesh, string name, string description)
        {
            add(new BlockType
            {
                Name = name,
                Description = description,
                IsCube = false,
                IsEmpty = false,
                IsSolid = false,
                Removable = true,
                Blocking = blocking,
                Texture = texture,
                Mesh = mesh
            });
        }

        public static uint count = 0;
        static void add(BlockType bt)
        {
            nameMap[bt.Name] = bt;
            blockTypes[bt.ID = count] = bt;
            count++;
        }
        static BlockType[] blockTypes;
        static Dictionary<string, BlockType> nameMap;

        public static BlockType FromID(uint id)
        {
            if (id < count)
                return blockTypes[id];
            return blockTypes[0];
        }
        public static BlockType FromID(string id)
        {
            BlockType bt;
            if (!nameMap.TryGetValue(id, out bt))
                return blockTypes[0];
            return bt;
        }
    }
}
