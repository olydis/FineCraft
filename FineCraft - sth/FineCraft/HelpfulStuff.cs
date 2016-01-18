using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading;
using FineCraft.Data;
using FineCraft.RenderEngine;
using Microsoft.Xna.Framework;

namespace FineCraft
{
    public static class HelpfulStuff
    {
        public static DirectoryInfo BaseDirectory
        {
            get
            {
                return new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;
            }
        }
        public static void Run(ThreadStart a)
        {
            Thread t = new Thread(a);
            t.IsBackground = true;
            t.Start();
        }
        public static void Try(Action a)
        {
            try
            {
                a();
            }
            catch { }
        }
        public static uint abs(uint i)
        {
            return i < 0x80000000 ? i : ~i;
        }
        public static uint abs(uint i, uint max)
        {
            return i < (max / 2) ? i : max - i;
        }
        public static void Clamp(int[,] _16x16, uint minmax)
        {
            for (int y = 0; y < 16; y++)
                for (int x = 0; x < 16; x++)
                    _16x16[x, y] = (int)(abs(((uint)_16x16[x, y] % (minmax * 4)) - minmax * 2) - minmax);
        }
        public static void ClampPos(int[,] _16x16, uint max)
        {
            for (int y = 0; y < 16; y++)
                for (int x = 0; x < 16; x++)
                    _16x16[x, y] = (int)abs(((uint)_16x16[x, y] % (max * 2)) - max);
        }

        public static AwesomeMesh getCube(float bBoxSize, Vector2 basis)
        {
            var cube = new VertexAwesome[36];

            cube[0] = new VertexAwesome(255, new Vector3(-bBoxSize, -bBoxSize, -bBoxSize), Vector3.Zero, basis);
            cube[4] = cube[1] = new VertexAwesome(255, new Vector3(-bBoxSize, bBoxSize, -bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureXUnit);
            cube[3] = cube[2] = new VertexAwesome(255, new Vector3(-bBoxSize, -bBoxSize, bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureYUnit);
            cube[5] = new VertexAwesome(255, new Vector3(-bBoxSize, bBoxSize, bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureXUnit + GraphicsHelper.TextureYUnit);
            cube[6] = new VertexAwesome(255, new Vector3(bBoxSize, -bBoxSize, -bBoxSize), Vector3.Zero, basis);
            cube[10] = cube[7] = new VertexAwesome(255, new Vector3(bBoxSize, -bBoxSize, bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureXUnit);
            cube[9] = cube[8] = new VertexAwesome(255, new Vector3(bBoxSize, bBoxSize, -bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureYUnit);
            cube[11] = new VertexAwesome(255, new Vector3(bBoxSize, bBoxSize, bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureXUnit + GraphicsHelper.TextureYUnit);

            cube[12] = new VertexAwesome(255, new Vector3(-bBoxSize, -bBoxSize, -bBoxSize), Vector3.Zero, basis);
            cube[16] = cube[13] = new VertexAwesome(255, new Vector3(-bBoxSize, -bBoxSize, bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureXUnit);
            cube[15] = cube[14] = new VertexAwesome(255, new Vector3(bBoxSize, -bBoxSize, -bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureYUnit);
            cube[17] = new VertexAwesome(255, new Vector3(bBoxSize, -bBoxSize, bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureXUnit + GraphicsHelper.TextureYUnit);
            cube[18] = new VertexAwesome(255, new Vector3(-bBoxSize, bBoxSize, -bBoxSize), Vector3.Zero, basis);
            cube[22] = cube[19] = new VertexAwesome(255, new Vector3(bBoxSize, bBoxSize, -bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureXUnit);
            cube[21] = cube[20] = new VertexAwesome(255, new Vector3(-bBoxSize, bBoxSize, bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureYUnit);
            cube[23] = new VertexAwesome(255, new Vector3(bBoxSize, bBoxSize, bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureXUnit + GraphicsHelper.TextureYUnit);

            cube[24] = new VertexAwesome(255, new Vector3(-bBoxSize, -bBoxSize, -bBoxSize), Vector3.Zero, basis);
            cube[28] = cube[25] = new VertexAwesome(255, new Vector3(bBoxSize, -bBoxSize, -bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureXUnit);
            cube[27] = cube[26] = new VertexAwesome(255, new Vector3(-bBoxSize, bBoxSize, -bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureYUnit);
            cube[29] = new VertexAwesome(255, new Vector3(bBoxSize, bBoxSize, -bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureXUnit + GraphicsHelper.TextureYUnit);
            cube[30] = new VertexAwesome(255, new Vector3(-bBoxSize, -bBoxSize, bBoxSize), Vector3.Zero, basis);
            cube[34] = cube[31] = new VertexAwesome(255, new Vector3(-bBoxSize, bBoxSize, bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureXUnit);
            cube[33] = cube[32] = new VertexAwesome(255, new Vector3(bBoxSize, -bBoxSize, bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureYUnit);
            cube[35] = new VertexAwesome(255, new Vector3(bBoxSize, bBoxSize, bBoxSize), Vector3.Zero, basis + GraphicsHelper.TextureXUnit + GraphicsHelper.TextureYUnit);

            return new AwesomeMesh(cube);
        }

        public static void RunPeriodic(Action a, int milliSeconds)
        {
            Timer t = null;
            TimerCallback tc = _ =>
            {
                a();
                t.Change(milliSeconds, Timeout.Infinite);
            };
            t = new Timer(tc);
            t.Change(milliSeconds, Timeout.Infinite);
        }
        public static void RunPeriodic(Action a, Func<int> milliSeconds)
        {
            Timer t = null;
            TimerCallback tc = _ =>
            {
                a();
                t.Change(milliSeconds(), Timeout.Infinite);
            };
            t = new Timer(tc);
            t.Change(milliSeconds(), Timeout.Infinite);
        }
    }
}
