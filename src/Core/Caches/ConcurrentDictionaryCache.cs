using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Core.Caches
{
    public class ConcurrentDictionaryCache<TKey, TResult> : ICache<TKey, TResult>
    {
        private readonly ConcurrentDictionary<TKey, TResult> _items = new ConcurrentDictionary<TKey, TResult>();

        public IEnumerable<KeyValuePair<TKey, TResult>> Items
        {
            get { return _items; }
        }

        public bool TryGetItem(TKey key, out TResult item)
        {
            return _items.TryGetValue(key, out item);
        }

        public TResult GetOrSetItem(TKey key, Func<TResult> itemFunc)
        {
            return _items.GetOrAdd(key, itemFunc());
        }

        public bool IsItemCached(TKey key)
        {
            return _items.ContainsKey(key);
        }

        public bool TryRemoveItem(TKey key)
        {
            TResult value;
            return _items.TryRemove(key, out value);
        }

        public void SetItem(TKey key, TResult item)
        {
            _items.AddOrUpdate(key, item, (k, i) => item);
        }

        public void SetItem(TKey key, Func<TResult> itemFunc)
        {
            _items.AddOrUpdate(key, itemFunc(), (k, i) => itemFunc());
        }

        public void SetItems(IEnumerable<KeyValuePair<TKey, TResult>> items)
        {
            foreach (var keyValuePair in items)
            {
                SetItem(keyValuePair.Key, keyValuePair.Value);
            }
        }
    }
}