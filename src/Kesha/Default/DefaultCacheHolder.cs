using System;
using System.Collections.Concurrent;

namespace Kesha.Default
{
    public class DefaultCacheHolder : ICacheHolder
    {
        private readonly ConcurrentDictionary<CacheKey, object> _caches = new ConcurrentDictionary<CacheKey, object>();

        public bool TryGet<TCache>(out TCache cache)
        {
            return TryGet(default(object), out cache);
        }

        public bool TryGet<TCacheKey, TCache>(TCacheKey scopeKey, out TCache cache)
        {
            var cacheKey = new CacheKey(scopeKey, typeof(TCache));

            object cacheFromDictionary;
            if (_caches.TryGetValue(cacheKey, out cacheFromDictionary))
            {
                cache = (TCache) cacheFromDictionary;
                return true;
            }

            cache = default(TCache);
            return false;
        }

        public bool TryAdd<TCache>(TCache cache)
        {
            return TryAdd(default(object), cache);
        }

        public bool TryAdd<TCacheKey, TCache>(TCacheKey scopeKey, TCache cache)
        {
            var cacheKey = new CacheKey(scopeKey, typeof(TCache));
            return _caches.TryAdd(cacheKey, cache);
        }

        private class CacheKey : Tuple<object, Type>
        {
            public CacheKey(object area, Type cacheType)
                : base(area, cacheType)
            {
            }
        }
    }
}