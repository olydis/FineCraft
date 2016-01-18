using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineCraft.DynamicObject
{
    public static class DynamicManager
    {
        static DynamicManager()
        {
            objects = new CDictionary<string, DynamicBase>();
            HelpfulStuff.RunPeriodic(update, 5000);
        }
        static CDictionary<string, DynamicBase> objects;

        static void update()
        {
            foreach (var o in objects.AsEnumerable)
                if(o.Value.Old)
                    objects.Remove(o.Key);
        }

        public static void Change(DynamicBase db)
        {
            db.Old = false;
            objects[db.ID] = db;
        }
        public static void Render()
        {
            foreach (var o in objects.Values)
                if(!o.DontDrawMyOwn)
                    o.Render();
        }
    }
}
