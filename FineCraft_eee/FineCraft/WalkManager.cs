using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FineCraft.Data;

namespace FineCraft
{
    class WalkManager
    {
        public WalkManager(GameManager game)
        {
            this.game = game;
        }
        GameManager game;

        public bool flightMode = false; //todo-remove

        float dZ, ds, df;
        float lastDZ;
        int sign(float f)
        {
            return f < 0 ? -1 : 1;
        }
        public void Tick()
        {
            if (!Static.Paused)
            {
                if (Backward)
                    df = (df - 3f) / 2;
                if (Forward)
                    df = (df + 3) / 2;
                if (Left)
                    ds = (ds - 3) / 2;
                if (Right)
                    ds = (ds + 3) / 2;
                if (flightMode)
                    dZ = (dZ - 1) < 0 ? 0 : (dZ - 1);
                else
                    dZ -= 1f;
                if (dZ < -10) dZ = -10;

                var orientation = game.Orientation;
                Vector3 delta = Vector3.Transform(new Vector3(ds / 10, df / 10, dZ / 10), Matrix.CreateRotationZ(-orientation.rotZ));

                if (delta.Z > 0)
                    switch (BlockTypes.FromID(game.GetValue(orientation.Position.X, orientation.Position.Y, (uint)(orientation.Position.Z + (int)Math.Ceiling(orientation.fZ + delta.Z)))).Blocking)
                    {
                        case BlockingType.Hard:
                            dZ = 0;
                            delta.Z = (int)Math.Ceiling(orientation.fZ + delta.Z) - 1 - orientation.fZ;
                            break;
                        case BlockingType.Liquid:
                            dZ *= 0.5f;
                            delta.Z *= 0.5f;
                            break;
                    }
                else if (delta.Z < 0)
                    switch (BlockTypes.FromID(game.GetValue(orientation.Position.X, orientation.Position.Y, (uint)(orientation.Position.Z + (int)Math.Floor(orientation.fZ + delta.Z)))).Blocking)
                    {
                        case BlockingType.Hard:
                            dZ = 0;
                            delta.Z = (int)Math.Floor(orientation.fZ + delta.Z) + 1 - orientation.fZ;
                            break;
                        case BlockingType.Liquid:
                            dZ *= 0.5f;
                            delta.Z *= 0.5f;
                            break;
                    }

                if (delta.X > 0)
                    switch (BlockTypes.FromID(game.GetValue((uint)(orientation.Position.X + (int)Math.Ceiling(orientation.fX + delta.X)), orientation.Position.Y, orientation.Position.Z)).Blocking)
                    {
                        case BlockingType.Hard:
                            delta.X = (int)Math.Ceiling(orientation.fX + delta.X) - 1 - orientation.fX;
                            break;
                        case BlockingType.Liquid:
                            delta.X *= 0.5f;
                            break;
                    }
                else if (delta.X < 0)
                    switch (BlockTypes.FromID(game.GetValue((uint)(orientation.Position.X + (int)Math.Floor(orientation.fX + delta.X)), orientation.Position.Y, orientation.Position.Z)).Blocking)
                    {
                        case BlockingType.Hard:
                            delta.X = (int)Math.Floor(orientation.fX + delta.X) + 1 - orientation.fX;
                            break;
                        case BlockingType.Liquid:
                            delta.X *= 0.5f;
                            break;
                    }

                if (delta.Y > 0)
                    switch (BlockTypes.FromID(game.GetValue(orientation.Position.X, (uint)(orientation.Position.Y + (int)Math.Ceiling(orientation.fY + delta.Y)), orientation.Position.Z)).Blocking)
                    {
                        case BlockingType.Hard:
                            delta.Y = (int)Math.Ceiling(orientation.fY + delta.Y) - 1 - orientation.fY;
                            break;
                        case BlockingType.Liquid:
                            delta.Y *= 0.5f;
                            break;
                    }
                else if (delta.Y < 0)
                    switch (BlockTypes.FromID(game.GetValue(orientation.Position.X, (uint)(orientation.Position.Y + (int)Math.Floor(orientation.fY + delta.Y)), orientation.Position.Z)).Blocking)
                    {
                        case BlockingType.Hard:
                            delta.Y = (int)Math.Floor(orientation.fY + delta.Y) + 1 - orientation.fY;
                            break;
                        case BlockingType.Liquid:
                            delta.Y *= 0.5f;
                            break;
                    }


                orientation.Move(delta);

                df *= 0.5f;
                ds *= 0.5f;
                if (Math.Abs(df) < 0.05f) df = 0;
                if (Math.Abs(ds) < 0.05f) ds = 0;
                lastDZ = dZ;
            }
        }

        public bool Forward { get; set; }
        public bool Backward { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }
        public void Jump()
        {
            if (lastDZ == 0 || flightMode)
                dZ = (float)((1 + Math.Sqrt(1 + 80 * game.settings.jumpHeight)) / 2) + 0.01f;
        }
    }
}
