using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Data;

namespace FineCraft.WorldGenerator
{
    public class Generator
    {
        public static int GenerateHeight(WorldPosition position)
        {
            return GenerateHeightmap(position, 1, 1)[0,0];
        }
        public static int[,] GenerateHeightmap(WorldPosition position, int realExp, int bufferExp)
        {
            var gebirge = VolumeGenerator.getData2D(0xFF, position.X, position.Y, realExp, bufferExp, 0x10000000, 0x100, 0x200);
            var height2 = VolumeGenerator.getData2D(1, position.X, position.Y, realExp, bufferExp, 0x10000000, -0x100, 0x180);
            //var gebirge = VolumeGenerator.getData2D(42, position.X, position.Y, realExp, bufferExp, 0x30000000, -0x20, 0x10);
            //var height2 = VolumeGenerator.getData2D(42, position.X, position.Y, realExp, bufferExp, 0x70000000, -0x10, 0x10);
            int bufferSize = 1 << bufferExp;
            var height = new int[bufferSize, bufferSize];
            for (int y = 0; y < bufferSize; y++)
                for (int x = 0; x < bufferSize; x++)
                    height[x, y] = gebirge[x,y] > 0 ?
                        (height2[x, y] + 0x10) :
                        height2[x, y];
                        //4;

            return height;
        }
        public static uint[, ,] GenerateChunk(WorldPosition position)
        {
            Func<string, uint> nameToId = id => BlockTypes.FromID(id).ID;

            var buffer = new uint[16, 16, 16];

            var height = GenerateHeightmap(position, 4, 4);
            
            int caveLayers = 20;
            //cave
            var caveData = Enumerable
                .Range(0x100, caveLayers)
                .Select(seed => VolumeGenerator.getData2D(seed, position.X, position.Y, 4, 4, 0x30000000, -0x30000000, 0x30000000))
                .ToArray();
            var caveDepth = Enumerable
                .Range(0x200, caveLayers)
                .Select(seed => VolumeGenerator.getData2D(seed, position.X, position.Y, 4, 4, 0x10000000, -0x400, 0x400))
                .ToArray();

            for (uint xx = 0; xx < 16; xx++)
                for (uint yy = 0; yy < 16; yy++)
                {
                    for (uint zz = 0; zz < 16; zz++)
                    {
                        int absoluteCurrentHeight = (int)(position.Z + zz - 0x80000000);
                        int absoluteGroundHeight = height[xx, yy];

                        if (-0x1100 < absoluteCurrentHeight && absoluteCurrentHeight < 0x1100)
                        {
                            int tiefe = absoluteGroundHeight - absoluteCurrentHeight;
                            if (tiefe >= 0)
                            {
                                uint radius = (uint)tiefe / 5 + 2;
                                if (radius > 10) radius = 10;

                                uint data;
                                bool cave;
                                bool noGround = false;
                                for (int i = 0; i < caveLayers; i++)
                                {
                                    data = (uint)caveData[i][xx, yy];
                                    data %= 0x40;
                                    data = HelpfulStuff.abs(data - 0x20);
                                    cave = data < radius;
                                    if (cave)
                                    {
                                        data = radius - data;
                                        cave = HelpfulStuff.abs((uint)absoluteCurrentHeight - (uint)caveDepth[i][xx, yy]) < data;
                                        if (!cave)
                                            cave = HelpfulStuff.abs((uint)absoluteCurrentHeight - (uint)caveDepth[(i + caveLayers / 8) % caveLayers][xx, yy] / 2) < data;
                                        if (!cave)
                                            cave = HelpfulStuff.abs((uint)absoluteCurrentHeight - (uint)caveDepth[(i + caveLayers * 2 / 8) % caveLayers][xx, yy] + 0x20) < data;
                                        if (!cave)
                                            cave = HelpfulStuff.abs((uint)absoluteCurrentHeight - (uint)caveDepth[(i + caveLayers * 3 / 8) % caveLayers][xx, yy] * 2) < data;
                                        if (!cave)
                                            cave = HelpfulStuff.abs((uint)absoluteCurrentHeight - (uint)caveDepth[(i + caveLayers * 4 / 8) % caveLayers][xx, yy]) < data;
                                        if (!cave)
                                            cave = HelpfulStuff.abs((uint)absoluteCurrentHeight - (uint)caveDepth[(i + caveLayers * 5 / 8) % caveLayers][xx, yy] / 2) < data;
                                        if (!cave)
                                            cave = HelpfulStuff.abs((uint)absoluteCurrentHeight - (uint)caveDepth[(i + caveLayers * 6 / 8) % caveLayers][xx, yy] - 0x20) < data;
                                        if (!cave)
                                            cave = HelpfulStuff.abs((uint)absoluteCurrentHeight - (uint)caveDepth[(i + caveLayers * 7 / 8) % caveLayers][xx, yy] * 2) < data;
                                    }
                                    if (cave)
                                    {
                                        buffer[xx, yy, zz] = nameToId("Air");
                                        goto done;
                                    }
                                }

                                if (tiefe == 0)
                                    buffer[xx, yy, zz] = /*noGround ? nameToId("Marble") :*/ nameToId("Grass");
                                else if (tiefe < 0x80)
                                    buffer[xx, yy, zz] = nameToId("Dirt");
                                else
                                    buffer[xx, yy, zz] = nameToId("Stone");

                            done: ;
                            }
                            else
                            {
                                if (tiefe == -1)
                                {
                                    if (absoluteGroundHeight > 0 && absoluteGroundHeight < 0x400)
                                        if (caveData[0][xx, yy] % 7 == 0 && caveData[1][xx, yy] % 3 == 0)
                                        {
                                            buffer[xx, yy, zz] = nameToId("Flower");
                                            goto noair;
                                        }
                                    if (absoluteGroundHeight > 0 && absoluteGroundHeight < 0x400)
                                        if (caveData[0][xx, yy] % 5 == 0 && caveData[1][xx, yy] % 3 == 0)
                                        {
                                            buffer[xx, yy, zz] = nameToId("Bush");
                                            goto noair;
                                        }
                                }
                                buffer[xx, yy, zz] = nameToId(absoluteCurrentHeight >= 0 ? "Air" : "Water");
                            noair: ;
                            }
                        }
                    }
                }
            return buffer;
        }
        /*public static uint[, ,] GenerateChunkSpaceWorld1(WorldPosition position)
        {
            var buffer = new uint[16, 16, 16];

            //var data1 = VolumeGenerator.getData2D(position.X, position.Y, 4, 4, 0x20000000);
            var data2 = VolumeGenerator.getData3D(position, 0, 0x1000000);

            for (uint xx = 0; xx < 16; xx++)
                for (uint yy = 0; yy < 16; yy++)
                    for (uint zz = 0; zz < 16; zz++)
                    {
                        //if (zz + position.Z < (uint)(0x80000000 + data1[xx,yy]))
                        uint joch = (uint)(0x80000000 + data2[xx, yy, zz]) % 0x1000;
                        if (0x800 > joch)
                            buffer[xx, yy, zz] = 3u;
                        else if (0xC00 > joch)
                            buffer[xx, yy, zz] = 2u;
                        else
                            buffer[xx, yy, zz] = 1;
                    }
            return buffer;
        }*/
    }
}
