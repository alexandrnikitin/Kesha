using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kesha
{
    public interface ICacheAsync<TKey, TResult> : ICache<TKey, TResult>
    {
        Task RemoveItemAsync(TKey key);

        Task SetItemAsync(TKey key, TResult item);

        Task SetItemAsync(TKey key, Func<TResult> itemFunc);

        Task SetItemsAsync(IEnumerable<KeyValuePair<TKey, TResult>> items);
    }
}