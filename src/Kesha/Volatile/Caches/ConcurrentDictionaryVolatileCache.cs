using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Kesha.Volatile.Caches
{
    public class ConcurrentDictionaryVolatileCache<TKey, TResult> : IVolatileCache<TKey, TResult>
    {
        private readonly ConcurrentDictionary<TKey, CacheEntry> _items = new ConcurrentDictionary<TKey, CacheEntry>();

        public bool TryGetItem(TKey key, out TResult item)
        {
            CacheEntry cacheEntry;
            if (_items.TryGetValue(key, out cacheEntry))
            {
                if (cacheEntry.InvalidationTokens.All(t => t != null && t.IsValid))
                {
                    item = cacheEntry.Result;
                    return true;
                }
            }

            item = default(TResult);
            return false;
        }

        public bool IsItemCached(TKey key)
        {
            TResult item;
            return TryGetItem(key, out item);
        }

        public bool TryRemoveItem(TKey key)
        {
            CacheEntry value;
            return _items.TryRemove(key, out value);
        }

        public void SetItem(TKey key, TResult item, IInvalidationToken invalidationToken)
        {
            var cacheEntry = new CacheEntry();
            cacheEntry.Result = item;
            cacheEntry.AddToken(invalidationToken);
            
            _items.AddOrUpdate(key, cacheEntry, (k, i) => cacheEntry);
        }

        public void SetItem(TKey key, Func<TResult> itemFunc, Func<IInvalidationToken> tokenFunc)
        {
            throw new NotImplementedException();
        }

        private class CacheEntry
        {
            private readonly IList<IInvalidationToken> _invalidationTokens = new List<IInvalidationToken>();

            public TResult Result { get; set; }

            public IEnumerable<IInvalidationToken> InvalidationTokens
            {
                get
                {
                    return _invalidationTokens;
                }
            }

            public void AddToken(IInvalidationToken invalidationToken)
            {
                _invalidationTokens.Add(invalidationToken);
            }
        }

    }
}