using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Network;
using Microsoft.Xna.Framework;
using FineCraft.RenderEngine;

namespace FineCraft.Data
{
    public class WorldOrientation : AwesomeSerializable
    {
        public WorldPosition Position = new WorldPosition();
        public Vector3 center;
        public float fX { get { return center.X; } set { center.X = value; } }
        public float fY { get { return center.Y; } set { center.Y = value; } }
        public float fZ { get { return center.Z; } set { center.Z = value; } }
        public float rotZ;
        public float rotX;

        public void Move(Vector3 delta)
        {
            center += delta;
            Normalize();
        }
        public void Goto(WorldPosition pos)
        {
            center = Vector3.Zero;
            Position = pos;
        }

        public void Normalize()
        {
            while (center.X < -0.5f)
            {
                Position.X--;
                center.X++;
            }
            while (center.X > 0.5f)
            {
                Position.X++;
                center.X--;
            }
            while (center.Y < -0.5f)
            {
                Position.Y--;
                center.Y++;
            }
            while (center.Y > 0.5f)
            {
                Position.Y++;
                center.Y--;
            }
            while (center.Z < -0.5f)
            {
                Position.Z--;
                center.Z++;
            }
            while (center.Z > 0.5f)
            {
                Position.Z++;
                center.Z--;
            }
        }

        public Matrix GetView()
        {
            return Matrix.CreateTranslation(-Vector3.UnitZ - center) * Matrix.CreateRotationZ(rotZ) * Matrix.CreateRotationX(-rotX) * Matrix.CreateLookAt(Vector3.Zero, Vector3.UnitY, Vector3.UnitZ);
        }
        public Matrix World
        {
            get
            {
                return Matrix.CreateRotationX(rotX) * Matrix.CreateRotationZ(-rotZ) * Matrix.CreateTranslation(center)
                    * Matrix.CreateTranslation(
                            (int)(Position.X - Static.Renderer.Volume.x),
                            (int)(Position.Y - Static.Renderer.Volume.y),
                            (int)(Position.Z - Static.Renderer.Volume.z));
            }
        }
        
        public override string ToString()
        {
            return "(" + Position.ToString() + ", " + rotZ.ToString("f") + ", " + rotX.ToString("f") + ")";
        }

        public override void Serialize(System.IO.BinaryWriter writer)
        {
            Position.Serialize(writer);
            writer.Write(fX);
            writer.Write(fY);
            writer.Write(fZ);
            writer.Write(rotZ);
            writer.Write(rotX);
        }
        public override void Deserialize(System.IO.BinaryReader reader)
        {
            Position.Deserialize(reader);
            fX = reader.ReadSingle();
            fY = reader.ReadSingle();
            fZ = reader.ReadSingle();
            rotZ = reader.ReadSingle();
            rotX = reader.ReadSingle();
        }
    }
}
