using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Network;
using System.Threading;
using System.Net;
using Microsoft.Xna.Framework;
using FineCraft.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using FineCraft.WorldGenerator;

namespace Test
{
    class Program
    {
        static Color getColor(int height)
        {
            if (height < 0)
                return Color.CornflowerBlue;
            height /= 0x20;
            height = Math.Min(255, height);
            return Color.FromArgb(height, 255 - height, 0);
        }
        static void Main(string[] args)
        {
            Bitmap b = new Bitmap(1024, 1024);

            var data1 = Generator.GenerateHeightmap(new WorldPosition
            {
                X = 0x80000000,
                Y = 0x80000000,
                Z = 0x80000000,
            }, 20, 10);
            for (int y = 0; y < 1024; y++)
                for (int x = 0; x < 1024; x++)
                    b.SetPixel(x, y, getColor(data1[x, y]));

            b.Save(@"C:\Dokumente und Einstellungen\Johannes\Desktop\map.png");
        }
    }
}
