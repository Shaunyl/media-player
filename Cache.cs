using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shauni
{
    public class Cache<K, D>
        where K : class
        where D : class
    {
        // Dictionary to contain the cache. 
        static Dictionary<K, WeakReference> _cache;

        public Cache()
        {
            _cache = new Dictionary<K, WeakReference>();
        }

        public void Add(K key, D item)
        {
            WeakReference value = null;

            if (_cache.TryGetValue(key, out value))
            {
                if (value == null)
                    _cache[key] = new WeakReference(item, false);
            }
            else
                _cache.Add(key, new WeakReference(item, false));
        }

        public bool Contains(K key)
        {
            return _cache.ContainsKey(key);
        }

        // Returns the number of items in the cache. 
        public int Count { get { return _cache.Count; } }

        // Accesses a data object from the cache. 
        // If the object was reclaimed for garbage collection, create a new data object at that index location. 
        public D this[K key]
        {
            get
            {
                // Obtain an instance of a data  object from the cache of  of weak reference objects.
                D d = (D)_cache[key].Target;

                if (d == null)
                    return null;

                return d;
            }

        }
    }
}
