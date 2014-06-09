using Autofac;
using Kesha.Caches;
using Kesha.Default;
using Kesha.Volatile;
using Kesha.Volatile.Caches;
using Kesha.Volatile.TokenProviders;

namespace Kesha.Autofac
{
    public class KeshaModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(ConcurrentDictionaryCache<,>)).As(typeof(ICache<,>)).AsSelf();
            builder.RegisterGeneric(typeof(ConcurrentDictionaryVolatileCache<,>)).As(typeof(IVolatileCache<,>)).AsSelf();

            builder.RegisterType<SignalInvalidator>().As<ISignalInvalidator>().SingleInstance();
            builder.RegisterType<DateTimeInvalidator>().As<IDateTimeInvalidator>().SingleInstance();

            builder.RegisterType<AutofacCacheFactory>().As<ICacheFactory>();
            builder.RegisterType<ConcurrentDictionaryCacheHolder>().As<ICacheHolder>().SingleInstance();
            builder.RegisterType<DefaultCacheManager>().As<ICacheManager>();
        }
    }
}