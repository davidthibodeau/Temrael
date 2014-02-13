using System;
using System.Collections.Generic;
using System.Text;

namespace Server.DataStructures
{
    public class OrderedDictionary<K, T> : IEnumerable<T>, ICollection<T>
    {
        private List<T> list;
        private List<K> listK;
        private Dictionary<K, T> dict;

        public OrderedDictionary()
        {
            list = new List<T>();
            listK = new List<K>();            
            dict = new Dictionary<K, T>();
        }

        public void Add(K key, T value)
        {
            list.Add(value);
            listK.Add(key);
            dict.Add(key, value);
        }

        public bool ContainsKey(K key)
        {
            return dict.ContainsKey(key);
        }

        public ICollection<K> Keys
        {
            get { return dict.Keys; }
        }

        public bool Remove(K key)
        {
            int i = listK.IndexOf(key);
            if (i == -1)
                return false;
            list.RemoveAt(i);
            return dict.Remove(key);
        }

        public bool TryGetValue(K key, out T value)
        {
            return dict.TryGetValue(key, out value);
        }

        public ICollection<T> Values
        {
            get { return dict.Values; }
        }

        public T this[K key]
        {
            get
            {
                return dict[key];
            }
            set
            {
                dict[key] = value;
                int i = listK.IndexOf(key);
                if (i != -1)
                    list[i] = value;                
            }
        }

        public T this[int i]
        {
            get
            {
                return list[i];
            }
            set
            {
                K k = listK[i];
                list[i] = value;
                dict[k] = value;
            }
        }

        public void Clear()
        {
            list.Clear();
            listK.Clear();
            dict.Clear();
        }

        public int Count
        {
            get { return dict.Count; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
