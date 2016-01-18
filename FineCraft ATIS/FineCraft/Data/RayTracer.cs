using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Windows.Forms;

namespace FineCraft.Data
{
    public static class RayTracer
    {
        static float Tail(float x)
        {
            return x - (int)Math.Floor(x);
        }
        static float NextFlip(float x, float d)
        {
            if (d < 0)
                return Tail(x - 0.5f) / -d;
            return (1 - Tail(x - 0.5f)) / d;
        }
        public static Vector3 NextNewBlock(Vector3 position, Vector3 delta, out Vector3 side)
        {
            float mx = NextFlip(position.X, delta.X);
            float my = NextFlip(position.Y, delta.Y);
            float mz = NextFlip(position.Z, delta.Z);
            float m = mx;
            side = delta.X < 0 ? Vector3.UnitX : -Vector3.UnitX;
            if (my < m)
            {
                m = my;
                side = delta.Y < 0 ? Vector3.UnitY : -Vector3.UnitY;
            }
            if (mz < m)
            {
                m = mz;
                side = delta.Z < 0 ? Vector3.UnitZ : -Vector3.UnitZ;
            }

            m += 0.001f;
            return position + delta * m;
        }
        public static WorldPosition FirstHit(GameManager gm, int maxDist, WorldPosition absoluteOffset, Matrix view)
        {
            Vector3 dummy;
            return FirstHitWithSide(gm, maxDist, absoluteOffset, view, out dummy);
        }
        public static WorldPosition FirstHit(GameManager gm, int maxDist, WorldPosition absoluteOffset, Vector3 offset, Vector3 delta)
        {
            Vector3 dummy;
            return FirstHitWithSide(gm, maxDist, absoluteOffset, offset, delta, out dummy);
        }
        public static WorldPosition FirstHitWithSide(GameManager gm, int maxDist, WorldPosition absoluteOffset, Matrix view, out Vector3 side)
        {
            view = Matrix.Invert(view);
            return FirstHitWithSide(gm, maxDist, absoluteOffset, view.Translation, view.Forward, out side);
        }
        public static WorldPosition FirstHitWithSide(GameManager gm, int maxDist, WorldPosition absoluteOffset, Vector3 offset, Vector3 delta, out Vector3 side)
        {
            Vector3 current = offset;

            WorldPosition pos = new WorldPosition();
            while (true)
            {
                current = NextNewBlock(current, delta, out side);
                if ((current - offset).Length() > maxDist)
                    return null;
                pos.X = (uint)(absoluteOffset.X + (int)Math.Round(current.X));
                pos.Y = (uint)(absoluteOffset.Y + (int)Math.Round(current.Y));
                pos.Z = (uint)(absoluteOffset.Z + (int)Math.Round(current.Z));
                uint value = gm.GetValue(
                                pos.X,
                                pos.Y,
                                pos.Z);
                if (!BlockTypes.FromID(value).IsEmpty)
                    return pos;
            }
        }
    }
}
