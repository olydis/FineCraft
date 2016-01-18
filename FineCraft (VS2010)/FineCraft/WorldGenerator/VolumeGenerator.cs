using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Data;

namespace FineCraft.WorldGenerator
{
    public static class VolumeGenerator
    {
        static int toleranceStep(int tolerance)
        {
            return tolerance * 7 / 10 + 2;
        }
        static int getTolerance(int maxTolerance)
        {
            return maxTolerance / 2;
        }
        static int toggleMode(int offset, int rand, int tolerance, int min, int max)
        {
            tolerance = Math.Min(tolerance, 8000);
            tolerance = Math.Min(tolerance, (max - min) / 2);
            int decision = ((rand % 3) - 1) * tolerance;
            if (decision > 0 && offset + decision > max)
                decision = (rand % 7 == 0) ? -decision : decision = max - offset;
            if (decision < 0 && offset + decision < min)
                decision = (rand % 7 == 0) ? -decision : decision = min - offset;
            return offset + decision;
        }

        static int[,] getData2D(int[,] bounds, int depth, int tolerance, int[,] seed, int sizeExp, int min, int max)
        {
            int totalSize, segmentSize, count = 1;
            totalSize = segmentSize = 1 << depth;
            int[,] data = new int[totalSize + 1, totalSize + 1];
            int[,] seeds = new int[totalSize + 1, totalSize + 1];
            data[0, 0] = bounds[0, 0];
            data[totalSize, 0] = bounds[1, 0];
            data[0, totalSize] = bounds[0, 1];
            data[totalSize, totalSize] = bounds[1, 1];
            seeds[0, 0] = seed[0, 0];
            seeds[totalSize, 0] = seed[1, 0];
            seeds[0, totalSize] = seed[0, 1];
            seeds[totalSize, totalSize] = seed[1, 1];
            FastRandom r = new FastRandom();
            while (segmentSize != 1)
            {
                for (int y = 0; y < count; y++)
                {
                    r.Reinitialise(seeds[totalSize, y * segmentSize] + sizeExp);

                    int ul = data[totalSize, y * segmentSize];
                    int dl = data[totalSize, (y + 1) * segmentSize];

                    r.Next();
                    r.Next();
                    int l = seeds[totalSize, y * segmentSize + segmentSize / 2] = r.Next();
                    l = toggleMode((ul + dl) / 2, l, tolerance, min, max);
                    data[totalSize, y * segmentSize + segmentSize / 2] = l;
                }
                for (int x = 0; x < count; x++)
                {
                    r.Reinitialise(seeds[x * segmentSize, totalSize] + sizeExp);

                    int ul = data[x * segmentSize, totalSize];
                    int ur = data[(x + 1) * segmentSize, totalSize];

                    r.Next();
                    int u = seeds[x * segmentSize + segmentSize / 2, totalSize] = r.Next();
                    u =  toggleMode((ul + ur) / 2 ,u, tolerance, min, max);
                    data[x * segmentSize + segmentSize / 2, totalSize] = u;
                }

                for (int y = 0; y < count; y++)
                    for (int x = 0; x < count; x++)
                    {
                        r.Reinitialise(seeds[x * segmentSize, y * segmentSize] + sizeExp);

                        int ul = data[x * segmentSize, y * segmentSize];
                        int ur = data[(x + 1) * segmentSize, y * segmentSize];
                        int dl = data[x * segmentSize, (y + 1) * segmentSize];
                        int dr = data[(x + 1) * segmentSize, (y + 1) * segmentSize];

                        int m = seeds[x * segmentSize + segmentSize / 2, y * segmentSize + segmentSize / 2] = r.Next();
                        int u = seeds[x * segmentSize + segmentSize / 2, y * segmentSize] = r.Next();
                        int l = seeds[x * segmentSize, y * segmentSize + segmentSize / 2] = r.Next();
                        m = toggleMode((ul + ur + dl + dr) / 4, m, tolerance, min, max);
                        u = toggleMode((ul + ur) / 2, u, tolerance, min, max);
                        l = toggleMode((ul + dl) / 2, l, tolerance, min, max);
                        data[x * segmentSize + segmentSize / 2, y * segmentSize + segmentSize / 2] = m;
                        data[x * segmentSize + segmentSize / 2, y * segmentSize] = u;
                        data[x * segmentSize, y * segmentSize + segmentSize / 2] = l;
                    }
                tolerance = getTolerance(tolerance);
                segmentSize /= 2;
                count *= 2;
                sizeExp--;
            }
            return data;
        }
        static void getBounds2D(int[,] bounds, int tolerance, int[,] seed, uint xx, uint yy, int depth, int min, int max)
        {
            int[,] data = new int[3, 3];
            int[,] seeds = new int[3, 3];
            data[0, 0] = bounds[0, 0];
            data[2, 0] = bounds[1, 0];
            data[0, 2] = bounds[0, 1];
            data[2, 2] = bounds[1, 1];
            seeds[0, 0] = seed[0, 0];
            seeds[2, 0] = seed[1, 0];
            seeds[0, 2] = seed[0, 1];
            seeds[2, 2] = seed[1, 1];
            FastRandom r = new FastRandom();

            r.Reinitialise(seeds[2, 0] + depth);
            r.Next();
            r.Next();
            int l = seeds[2, 1] = r.Next();
            l = toggleMode((data[2, 0] + data[2, 2]) / 2, l, tolerance, min, max);
            data[2, 1] = l;

            r.Reinitialise(seeds[0, 2] + depth);
            r.Next();
            int u = seeds[1, 2] = r.Next();
            u = toggleMode((data[0, 2] + data[2, 2]) / 2, u, tolerance, min, max);
            data[1, 2] = u;

            r.Reinitialise(seeds[0, 0] + depth);
            int ul = data[0, 0];
            int ur = data[2, 0];
            int dl = data[0, 2];
            int dr = data[2, 2];
            int m = seeds[1, 1] = r.Next();
            u = seeds[1, 0] = r.Next();
            l = seeds[0, 1] = r.Next();
            m = toggleMode((ul + ur + dl + dr) / 4, m, tolerance, min, max);
            u = toggleMode((ul + ur) / 2, u, tolerance, min, max);
            l = toggleMode((ul + dl) / 2, l, tolerance, min, max);
            data[1, 1] = m;
            data[1, 0] = u;
            data[0, 1] = l;

            bounds[0, 0] = data[xx, yy];
            bounds[1, 0] = data[xx + 1, yy];
            bounds[0, 1] = data[xx, yy + 1];
            bounds[1, 1] = data[xx + 1, yy + 1];
            seed[0, 0] = seeds[xx, yy];
            seed[1, 0] = seeds[xx + 1, yy];
            seed[0, 1] = seeds[xx, yy + 1];
            seed[1, 1] = seeds[xx + 1, yy + 1];
            return;
        }
        public static int[,] getData2D(int seedy, uint x, uint y, int realSize, int imageSize, int tolerance, int min, int max)
        {
            realSize = 32 - realSize;
            int[,] bounds = new int[,] { { 0, 0 }, { 0, 0 } };
            int[,] seed = new int[,] { { seedy, seedy }, { seedy, seedy } };
            int depth = 32;
            while (realSize != 0)
            {
                getBounds2D(bounds, tolerance, seed, (x & 0x80000000) >> 31, (y & 0x80000000) >> 31, depth, min, max);
                depth--;
                tolerance = getTolerance(tolerance);
                realSize--;
                x <<= 1;
                y <<= 1;
            }
            return getData2D(bounds, imageSize, tolerance, seed, depth, min, max);
        }

        public static int[, ,] getData3D(WorldPosition chunkPosition, int seed, int tolerance)
        {
            int[, ,] buffer = new int[3,3,3];
            for (int i = 31; i > 3; i--)
            {
                var seeds = getFrame3D(buffer, 0, 0, 0, 1, seed, tolerance);
                tolerance = toleranceStep(tolerance);
                uint x = (chunkPosition.X >> i) & 1;
                uint y = (chunkPosition.Y >> i) & 1;
                uint z = (chunkPosition.Z >> i) & 1;
                seed = seeds[x, y, z];
                seed += toSeedComponent(chunkPosition.X & (0xFFFFFFFF << i), chunkPosition.Y & (0xFFFFFFFF << i), chunkPosition.Z & (0xFFFFFFFF << i));
                buffer[2 - 2 * x, 2 - 2 * y, 2 - 2 * z] = buffer[1, 1, 1];
                buffer[2 * x, 2 - 2 * y, 2 - 2 * z] = buffer[2 * x, 1, 1];
                buffer[2 - 2 * x, 2 * y, 2 - 2 * z] = buffer[1, 2 * y, 1];
                buffer[2 * x, 2 * y, 2 - 2 * z] = buffer[2 * y, 2 * y, 1];
                buffer[2 - 2 * x, 2 - 2 * y, 2 * z] = buffer[1, 1, 2 * z];
                buffer[2 * x, 2 - 2 * y, 2 * z] = buffer[2 * x, 1, 2 * z];
                buffer[2 - 2 * x, 2 * y, 2 * z] = buffer[1, 2 * y, 2 * z];
            }
            int[, ,] chunk = new int[17, 17, 17];
            chunk[0, 0, 0] = buffer[0, 0, 0];
            chunk[16, 0, 0] = buffer[2, 0, 0];
            chunk[0, 16, 0] = buffer[0, 2, 0];
            chunk[16, 16, 0] = buffer[2, 2, 0];
            chunk[0, 0, 16] = buffer[0, 0, 2];
            chunk[16, 0, 16] = buffer[2, 0, 2];
            chunk[0, 16, 16] = buffer[0, 2, 2];
            chunk[16, 16, 16] = buffer[2, 2, 2];
            fillBuffer3D(chunkPosition, chunk, 0, 0, 0, 3, seed, tolerance);

            interpolate(chunk);
            interpolate(chunk);
            interpolate(chunk);
            interpolate(chunk);

            return chunk;
        }
        static void fillBuffer3D(WorldPosition chunkPosition, int[, ,] buffer, int x, int y, int z, int exp, int seed, int tolerance)
        {
            int d = 1 << exp;
            var seeds = getFrame3D(buffer, x, y, z, d, seed, tolerance);
            tolerance = toleranceStep(tolerance);
            for (int xx = 0; xx < 2; xx++)
                for (int yy = 0; yy < 2; yy++)
                    for (int zz = 0; zz < 2; zz++)
                    {
                        seed = seeds[xx, yy, zz] + toSeedComponent(chunkPosition.X + (uint)(x + xx * d), chunkPosition.Y + (uint)(y + yy * d), chunkPosition.Z + (uint)(z + zz * d));
                        if(d != 1)
                            fillBuffer3D(chunkPosition, buffer, x + xx * d, y + yy * d, z + zz * d, exp - 1, seed, tolerance);
                    }
        }
        static int[, ,] getFrame3D(int[, ,] buffer, int x, int y, int z, int d, int seed, int tolerance)
        {
            int[, ,] seeds = new int[2, 2, 2];
            int[, ,] e = new int[2, 2, 2];
            FastRandom random = new FastRandom(seed);
            for (int xx = 0; xx < 2; xx++)
                for (int yy = 0; yy < 2; yy++)
                    for (int zz = 0; zz < 2; zz++)
                    {
                        seeds[xx, yy, zz] = random.Next() + xx + 2 * yy + 4 * zz;
                        e[xx, yy, zz] = buffer[x + 2 * xx * d, y + 2 * yy * d, z + 2 * zz * d];
                    }
            Func<int, int> delta = i => i + (random.Next() % tolerance) - (tolerance / 2);
            //center cube
            buffer[x + d, y + d, z + d] = delta((
                e[0, 0, 0] +
                e[0, 0, 1] +
                e[0, 1, 0] +
                e[0, 1, 1] +
                e[1, 0, 0] +
                e[1, 0, 1] +
                e[1, 1, 0] +
                e[1, 1, 1]) / 8);
            //center face
            buffer[x, y + d, z + d] = delta((
                e[0, 0, 0] +
                e[0, 0, 1] +
                e[0, 1, 0] +
                e[0, 1, 1]) / 4);
            buffer[x + 2 * d, y + d, z + d] = delta((
                e[1, 0, 0] +
                e[1, 0, 1] +
                e[1, 1, 0] +
                e[1, 1, 1]) / 4);
            buffer[x + d, y, z + d] = delta((
                e[0, 0, 0] +
                e[0, 0, 1] +
                e[1, 0, 0] +
                e[1, 0, 1]) / 4);
            buffer[x + d, y + 2 * d, z + d] = delta((
                e[0, 1, 0] +
                e[0, 1, 1] +
                e[1, 1, 0] +
                e[1, 1, 1]) / 4);
            buffer[x + d, y + d, z] = delta((
                e[0, 0, 0] +
                e[0, 1, 0] +
                e[1, 0, 0] +
                e[1, 1, 0]) / 4);
            buffer[x + d, y + d, z + 2 * d] = delta((
                e[0, 0, 1] +
                e[0, 1, 1] +
                e[1, 0, 1] +
                e[1, 1, 1]) / 4);
            //center line
            buffer[x, y, z + d] = delta((e[0, 0, 0] + e[0, 0, 1]) / 2);
            buffer[x + 2 * d, y, z + d] = delta((e[1, 0, 0] + e[1, 0, 1]) / 2);
            buffer[x, y + 2 * d, z + d] = delta((e[0, 1, 0] + e[0, 1, 1]) / 2);
            buffer[x + 2 * d, y + 2 * d, z + d] = delta((e[1, 1, 0] + e[1, 1, 1]) / 2);

            buffer[x, y + d, z] = delta((e[0, 0, 0] + e[0, 1, 0]) / 2);
            buffer[x + 2 * d, y + d, z] = delta((e[1, 0, 0] + e[1, 1, 0]) / 2);
            buffer[x, y + d, z + 2 * d] = delta((e[0, 0, 1] + e[0, 1, 1]) / 2);
            buffer[x + 2 * d, y + d, z + 2 * d] = delta((e[1, 0, 1] + e[1, 1, 1]) / 2);

            buffer[x + d, y, z] = delta((e[0, 0, 0] + e[1, 0, 0]) / 2);
            buffer[x + d, y + 2 * d, z] = delta((e[0, 1, 0] + e[1, 1, 0]) / 2);
            buffer[x + d, y, z + 2 * d] = delta((e[0, 0, 1] + e[1, 0, 1]) / 2);
            buffer[x + d, y + 2 * d, z + 2 * d] = delta((e[0, 1, 1] + e[1, 1, 1]) / 2);

            return seeds;
        }
        static void interpolate(int[, ,] buffer)
        {
            for (int x = 0; x < 16; x++)
                for (int y = 0; y < 16; y++)
                    for (int z = 0; z < 16; z++)
                        buffer[x, y, z] = (
                            buffer[x, y, z] +
                            buffer[x + 1, y, z] +
                            buffer[x, y + 1, z] +
                            buffer[x + 1, y + 1, z] +
                            buffer[x, y, z + 1] +
                            buffer[x + 1, y, z + 1] +
                            buffer[x, y + 1, z + 1] +
                            buffer[x + 1, y + 1, z + 1]) / 8;
        }
        static int toSeedComponent(uint x, uint y, uint z)
        {
            return (int)((x & 0x1337) + (y >> 3) + (z ^ 0xDEADBEAF));
        }
        static int clamp(int i, int min, int max)
        {
            if (i < min)
                return min;
            if (i > max)
                return max;
            return i;
        }
    }
}
