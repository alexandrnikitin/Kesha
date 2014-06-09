using System;

namespace Kesha.Default
{
    public class DefaultCacheFactory : ICacheFactory
    {
        public TCache Create<TCache>()
        {
            return Activator.CreateInstance<TCache>();
        }

        public object Create(Type cacheType)
        {
            return Activator.CreateInstance(cacheType);
        }
    }
}