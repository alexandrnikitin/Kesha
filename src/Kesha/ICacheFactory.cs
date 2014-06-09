using System;

namespace Kesha
{
    public interface ICacheFactory
    {
        TCache Create<TCache>();

        object Create(Type cacheType);
    }
}