namespace DeclarativeLayout
{
    using System;
    using System.Collections.Generic;

    public class GenericFileObjectCache<TItem>
    {
        private Dictionary<string, TItem> cache;

        public GenericFileObjectCache()
        {
            this.cache = new Dictionary<string, TItem>();
        }

        public delegate TItem LoadItem();

        public void CacheItem(string path, TItem item)
        {
            if (this.cache.ContainsKey(path))
            {
                throw new InvalidOperationException("Item already cached.");
            }

            this.cache.Add(path, item);
        }

        public TItem GetCachedItem(string path)
        {
            if (this.cache.ContainsKey(path))
            {
                return this.cache[path];
            }

            throw new InvalidOperationException("Item not cached.");
        }

        public TItem CacheAndGetItem(string path, LoadItem loadItem)
        {
            if (this.cache.ContainsKey(path))
            {
                return this.cache[path];
            }
            else
            {
                TItem item = loadItem.Invoke();
                this.CacheItem(path, item);
                return item;
            }
        }
    }
}
