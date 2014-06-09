using Autofac;

namespace Kesha.Autofac
{
    public class AutofacCacheFactory : ICacheFactory
    {
        private readonly ILifetimeScope _lifetimescope;

        public AutofacCacheFactory(ILifetimeScope lifetimescope)
        {
            _lifetimescope = lifetimescope;
        }

        public TCache Create<TCache>()
        {
            return _lifetimescope.Resolve<TCache>();
        }
    }
}