using System;

namespace Kesha.Default
{
    public class DefaultCacheFactory : ICacheFactory
    {
        public TCache Create<TCache>()
        {
            return Activator.CreateInstance<TCache>();
        }
    }
}