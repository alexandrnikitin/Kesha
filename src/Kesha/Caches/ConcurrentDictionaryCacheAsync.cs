using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kesha.Caches
{
    public class ConcurrentDictionaryCacheAsync<TKey, TResult> :
        ConcurrentDictionaryCache<TKey, TResult>, 
        ICacheAsync<TKey, TResult>
    {
        public Task RemoveItemAsync(TKey key)
        {
            return Task.Run(() => this.TryRemoveItem(key));
        }

        public Task SetItemAsync(TKey key, TResult item)
        {
            return Task.Run(() => this.SetItem(key, item));
        }

        public Task SetItemAsync(TKey key, Func<TResult> itemFunc)
        {
            return Task.Run(() => this.SetItem(key, itemFunc));
        }

        public Task SetItemsAsync(IEnumerable<KeyValuePair<TKey, TResult>> items)
        {
            return Task.Run(() => this.SetItems(items));
        }
    }
}