using System;
using System.Collections.Generic;

namespace Kesha
{
    public interface ICache<TKey, TResult>
    {
        IEnumerable<KeyValuePair<TKey, TResult>> Items { get; }

        TResult GetOrSetItem(TKey key, Func<TResult> itemFunc);

        bool IsItemCached(TKey key);

        void SetItem(TKey key, TResult item);

        void SetItem(TKey key, Func<TResult> itemFunc);

        void SetItems(IEnumerable<KeyValuePair<TKey, TResult>> items);

        bool TryGetItem(TKey key, out TResult item);

        bool TryRemoveItem(TKey key);
    }
}