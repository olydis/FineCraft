using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineCraft.Data;
using FineCraft;

namespace Server
{
    public class PhysicsManager
    {
        public PhysicsManager(MainWindow server)
        {
            this.server = server;
            toUpdate = new Queue<WorldPosition>();
            HelpfulStuff.RunPeriodic(doWork, 200);
        }
        MainWindow server;

        public void Update(WorldPosition wp)
        {
            lock (toUpdate)
                toUpdate.Enqueue(wp);
        }

        Queue<WorldPosition> toUpdate;

        void doWork()
        {
            if (toUpdate.Count != 0)
            {
                Queue<WorldPosition> cache;
                lock (toUpdate)
                {
                    cache = toUpdate;
                    toUpdate = new Queue<WorldPosition>();
                }

                while (cache.Count != 0)
                    ValidatePhysics(cache.Dequeue());
            }
        }

        void ValidatePhysics(WorldPosition wp)
        {

        }
    }
}
