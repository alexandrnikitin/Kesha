using System;

namespace Kesha.Volatile
{
    public interface IVolatileCache<TKey, TResult>
    {
        bool IsItemCached(TKey key);

        void SetItem(TKey key, TResult item, IToken token);

        void SetItem(TKey key, Func<TResult> itemFunc, Func<IToken> tokenFunc);

        bool TryGetItem(TKey key, out TResult item);

        bool TryRemoveItem(TKey key);
    }
}