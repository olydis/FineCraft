using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineCraft
{
    public class CDictionary<TKey, TValue>
    {
        public CDictionary()
        {
            dict = new Dictionary<TKey, TValue>();
        }

        Dictionary<TKey, TValue> dict;

        public TValue this[TKey key]
        {
            get
            {
                lock (dict)
                    return dict[key];
            }
            set
            {
                lock (dict)
                    dict[key] = value;
            }
        }
        public void Remove(TKey key)
        {
            lock (dict)
                dict.Remove(key);
        }
        public void Add(TKey key, TValue value)
        {
            lock (dict)
                dict.Add(key, value);
        }
        public bool ContainsKey(TKey key)
        {
            lock (dict)
                return dict.ContainsKey(key);
        }
        public List<TValue> Values
        {
            get
            {
                lock (dict)
                    return dict.Values.ToList();
            }
        }
        public List<TKey> Keys
        {
            get
            {
                lock (dict)
                    return dict.Keys.ToList();
            }
        }

        public void Clear()
        {
            lock (dict)
                dict.Clear();
        }

        public List<KeyValuePair<TKey, TValue>> AsEnumerable
        {
            get
            {
                lock (dict)
                    return dict.ToList();
            }
        }
    }
}
