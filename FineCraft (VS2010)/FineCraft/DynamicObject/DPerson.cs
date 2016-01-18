using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.RenderEngine;
using FineCraft.Data;

namespace FineCraft.DynamicObject
{
    public class DPerson : DynamicBase
    {
        public static void Init()
        {
            Mesh = HelpfulStuff.getCube(0.5f, GraphicsHelper.TextureCoord(136));
        }
        static AwesomeMesh Mesh;


        public DPerson() { }
        public DPerson(string name)
        {
            Name = name;
            ID = "P" + name;
        }

        public string Name { get; private set; }

        protected override void SerializeSub(System.IO.BinaryWriter writer)
        {
            writer.Write(Name);
        }
        protected override void DeserializeSub(System.IO.BinaryReader reader)
        {
            Name = reader.ReadString();
        }

        public override void Render()
        {
            Mesh.Draw(Orientation);
        }
    }
}
