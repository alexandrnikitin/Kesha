using System;

namespace Kesha.Volatile
{
    public interface IVolatileCache<TKey, TResult>
    {
        bool TryGetItem(TKey key, out TResult item);

        bool IsItemCached(TKey key);

        bool TryRemoveItem(TKey key);

        void SetItem(TKey key, TResult item, IInvalidationToken invalidationToken);

        void SetItem(TKey key, Func<TResult> itemFunc, Func<IInvalidationToken> tokenFunc);
    }
}