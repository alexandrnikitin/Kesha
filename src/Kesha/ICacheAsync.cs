using System;
using System.Collections.Generic;

namespace Kesha
{
    public interface ICacheAsync<TKey, TResult> : ICache<TKey, TResult>
    {
        void RemoveItemAsync(TKey key);

        void SetItemAsync(TKey key, TResult item);

        void SetItemAsync(TKey key, Func<TResult> itemFunc);

        void SetItemsAsync(IEnumerable<KeyValuePair<TKey, TResult>> items);
    }
}