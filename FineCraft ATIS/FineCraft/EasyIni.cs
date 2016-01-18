using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace FineCraft
{
    public class EasyIni
    {
        public EasyIni(string name)
        {
            path = HelpfulStuff.BaseDirectory.FullName + "\\" + name + ".ini";

            Read();
        }

        void Read()
        {
            data = new Dictionary<string, string>();
            try
            { 
                foreach (string line in File.ReadAllLines(path))
                {
                    string[] parts = line.Split('=').Select(s => s.Trim()).ToArray();
                    if (parts.Length != 2)
                        continue;
                    data[parts[0]] = parts[1];
                }
            }
            catch { }
        }
        void Write()
        {
            File.WriteAllLines(path, data.Select(kvp => kvp.Key + " = " + kvp.Value).ToArray());
        }

        string path;
        Dictionary<string, string> data;

        public T Get<T>(string id, T alternative)
        {
            id = id.ToLower();
            return data.ContainsKey(id) ? (T)Convert.ChangeType(data[id], typeof(T)) : alternative;
        }
        public void Set<T>(string id, T value)
        {
            id = id.ToLower();
            data[id] = Convert.ToString(value);
        }

        public void Save()
        {
            Write();
        }
    }
}
