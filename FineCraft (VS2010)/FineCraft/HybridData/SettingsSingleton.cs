using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FineCraft.Data;

namespace FineCraft.HybridData
{
    public class SettingsSingleton : HybridObject
    {
        static readonly string key = "Settings";
        public override string Key { get { return key; } }
        public static Settings RegisterSettings(uint userid)
        {
            var s = GetObject<SettingsSingleton>(key, userid);
            if (s == null)
            {
                s = new SettingsSingleton();
                RegisterNewObject(s, true);
                return GetObject<SettingsSingleton>(key, userid).s;
            }
            return s.s;
        }
        public static SettingsSingleton TryGetSettings()
        {
            return TryGetObject<SettingsSingleton>(key);
        }

        public Settings s = new Settings();

        public override void Serialize(BinaryWriter writer)
        {
            s.Serialize(writer);
        }

        public override void Deserialize(BinaryReader reader)
        {
            s.Deserialize(reader);
        }
    }
}
