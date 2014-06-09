using System;
using System.Collections.Generic;

namespace Kesha
{
    public interface ICache<TKey, TResult>
    {
        IEnumerable<KeyValuePair<TKey, TResult>> Items { get; }

        bool TryGetItem(TKey key, out TResult item);

        TResult GetOrSetItem(TKey key, Func<TResult> itemFunc);

        bool IsItemCached(TKey key);

        bool TryRemoveItem(TKey key);
        
        void SetItem(TKey key, TResult item);

        void SetItem(TKey key, Func<TResult> itemFunc);

        void SetItems(IEnumerable<KeyValuePair<TKey, TResult>> items);
    }
}