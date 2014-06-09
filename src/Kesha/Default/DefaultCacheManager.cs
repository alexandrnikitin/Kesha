using System;

namespace Kesha.Default
{
    public class DefaultCacheManager : ICacheManager
    {
        private readonly ICacheFactory _cacheFactory;

        private readonly ICacheHolder _cacheHolder;

        public DefaultCacheManager(ICacheHolder cacheHolder, ICacheFactory cacheFactory)
        {
            _cacheHolder = cacheHolder;
            _cacheFactory = cacheFactory;
        }

        public TCache Get<TCache>()
        {
            TCache cache;
            if (_cacheHolder.TryGet(out cache))
            {
                return cache;
            }

            cache = _cacheFactory.Create<TCache>();
            if (_cacheHolder.TryAdd(cache))
            {
                return cache;
            }

            throw new InvalidOperationException("Can't get cache from cache holder.");
        }
    }
}