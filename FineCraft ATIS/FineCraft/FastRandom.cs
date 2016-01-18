using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineCraft
{
    class FastRandom
    {
        uint x, y, z, w;

        public static int Single(int seed)
        {
            seed ^= seed << 11;
            seed ^= seed >> 8;
            seed ^= 273327012;
            return 0x7FFFFFFF & seed;
        }

        public FastRandom() { }
        public FastRandom(int seed) { Reinitialise(seed); }
        public void Reinitialise(int seed)
        {
            x = (uint)seed;
            y = 842502087;
            z = 3579807591;
            w = 273326509;
        }

        public int Next()
        {
            uint t = x ^ (x << 11);
            x = y; y = z; z = w;
            return (int)(0x7FFFFFFF & (w = (w ^ (w >> 19)) ^ (t ^ (t >> 8))));
        }
    }
}
