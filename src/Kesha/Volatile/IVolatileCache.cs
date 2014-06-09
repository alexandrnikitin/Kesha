﻿using System;

namespace Kesha.Volatile
{
    public interface IVolatileCache<TKey, TResult>
    {
        bool TryGetItem(TKey key, out TResult item);

        bool IsItemCached(TKey key);

        bool TryRemoveItem(TKey key);

        void SetItem(TKey key, TResult item, IToken token);

        void SetItem(TKey key, Func<TResult> itemFunc, Func<IToken> tokenFunc);
    }
}