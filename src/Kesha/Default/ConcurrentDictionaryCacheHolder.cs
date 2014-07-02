using System;
using System.Collections.Concurrent;

namespace Kesha.Default
{
    public class ConcurrentDictionaryCacheHolder : ICacheHolder
    {
        private readonly ConcurrentDictionary<CacheKey, object> _caches = new ConcurrentDictionary<CacheKey, object>();

        public bool TryAdd<TCache>(TCache cache)
        {
            return TryAdd(default(object), cache);
        }

        public bool TryAdd<TScope, TCache>(TScope scope, TCache cache)
        {
            var cacheKey = new CacheKey(scope, typeof(TCache));
            return _caches.TryAdd(cacheKey, cache);
        }

        public bool TryGet<TCache>(out TCache cache)
        {
            return TryGet(default(object), out cache);
        }

        public bool TryGet<TScope, TCache>(TScope scope, out TCache cache)
        {
            var cacheKey = new CacheKey(scope, typeof(TCache));

            object cacheFromDictionary;
            if (_caches.TryGetValue(cacheKey, out cacheFromDictionary))
            {
                cache = (TCache)cacheFromDictionary;
                return true;
            }

            cache = default(TCache);
            return false;
        }

        private class CacheKey : Tuple<object, Type>
        {
            public CacheKey(object scope, Type cacheType)
                : base(scope, cacheType)
            {
            }
        }
    }
}