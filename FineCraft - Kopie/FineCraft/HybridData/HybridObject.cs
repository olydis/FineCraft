using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FineCraft.Network;

namespace FineCraft.HybridData
{
    public abstract class HybridObject : AwesomeSerializable
    {
        string Class { get { return GetType().Name; } }
        public abstract string Key { get; }
        HashSet<uint> registered = new HashSet<uint>();
        bool Dirty;

        public int LifeCount { get { return registered.Count; } }

        void Save()
        {
            AwesomeFormatter af = new AwesomeFormatter();
            DirectoryInfo di = new FileInfo(FileName(this)).Directory;
            if (!di.Exists) di.Create();
            using (Stream s = File.Create(FileName(this)))
                af.SerializeKnown(s, this);
        }

        public IEnumerable<uint> WhoKnows()
        {
            return registered.ToList();
        }
        public IEnumerable<uint> MakeDirty()
        {
            Dirty = true;
            return registered;
        }
        public void Useless(uint userid)
        {
            registered.Remove(userid);
        }

        static HybridObject()
        {
            BaseFolder = Directory.GetCurrentDirectory() + "\\";
            Cache = new CDictionary<string, HybridObject>();
            HelpfulStuff.RunPeriodic(visitorThread, 10000);
        }

        static readonly string ext = ".txt";
        static string FileName<T>(string key)
        {
            return BaseFolder + typeof(T).Name + "\\" + key + ext;
        }
        static string FileName(HybridObject o)
        {
            return BaseFolder + o.Class + "\\" + o.Key + ext;
        }
        static string CacheKey<T>(string key)
        {
            return typeof(T).Name + "_" + key;
        }
        static string CacheKey(HybridObject o)
        {
            return o.Class + "_" + o.Key;
        }

        public static void RegisterNewObject(HybridObject o, bool isdirty)
        {
            o.Dirty = false;
            if (isdirty)
                o.Save();
            string cKey = CacheKey(o);
            lock (Cache)
                Cache[cKey] = o;
        }
        public static void UnregisterObject(HybridObject o)
        {
            o.Dirty = true;
            string cKey = CacheKey(o);
            File.Delete(FileName(o));
            lock (Cache)
                Cache.Remove(cKey);
        }
        static void Load<T>(string key) where T : HybridObject, new()
        {
            AwesomeFormatter af = new AwesomeFormatter();
            lock (Cache)
                if (File.Exists(FileName<T>(key)))
                    using (Stream s = File.OpenRead(FileName<T>(key)))
                        (Cache[CacheKey<T>(key)] = af.DeserializeKnown<T>(s)).Dirty = false;
        }
        public static T GetObject<T>(string key, uint userid) where T : HybridObject, new()
        {
            var o = GetObject<T>(key);
            if (o == null)
                return null;
            o.registered.Add(userid);
            return o;
        }
        public static T GetObject<T>(string key) where T : HybridObject, new()
        {
            string cKey = CacheKey<T>(key);
            lock (Cache)
            {
                if (!Cache.ContainsKey(cKey))
                    Load<T>(key);
                if (!Cache.ContainsKey(cKey))
                    return null;
                var o = Cache[cKey];
                return o as T;
            }
        }
        public static bool HasObject<T>(string key) where T : HybridObject
        {
            string cKey = CacheKey<T>(key);
            lock (Cache)
                if (Cache.ContainsKey(cKey))
                    return true;
            return File.Exists(FileName<T>(key));
        }
        public static IEnumerable<string> GetAvailable<T>()
        {
            var di = new DirectoryInfo(BaseFolder + typeof(T).Name);
            if (di.Exists)
                foreach (var s in di.GetFiles("*" + ext))
                    yield return s.Name.Substring(0, s.Name.Length - ext.Length);
        }

        public static T TryGetObject<T>(string key) where T : HybridObject, new()
        {
            string cKey = CacheKey<T>(key);
            lock (Cache)
            {
                if (!Cache.ContainsKey(cKey))
                    return null;
                var o = Cache[cKey];
                return o as T;
            }
        }

        public static void UnregisterUser(uint userid)
        {
            lock (Cache)
                foreach (var o in Cache.Values)
                    o.Useless(userid);
        }
        public static IEnumerable<HybridObject> GetLoaded()
        {
            return Cache.Values;
        }

        static string BaseFolder;
        static CDictionary<string, HybridObject> Cache;

        static void visitorThread()
        {
            List<HybridObject> cacheCopy;
            lock (Cache)
                cacheCopy = Cache.Values.ToList();
            foreach (var o in cacheCopy)
                Visit(o);
        }

        static void Visit(HybridObject o)
        {
            if (o.Dirty)
                o.Save();
            if (o.registered.Count == 0)
                Cache.Remove(CacheKey(o));
        }

        public override string ToString()
        {
            return "Count: " + registered.Count;
        }
    }
}
