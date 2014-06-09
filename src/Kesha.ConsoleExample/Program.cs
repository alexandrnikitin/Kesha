using System;
using Autofac;
using Kesha.Autofac;
using Kesha.Default;

namespace Kesha.ConsoleExample
{
    class Program
    {
        static void Main()
        {
            PlainExample();
            IocExample();


            Console.WriteLine("Finished");
            Console.ReadKey();
        }

        private static void IocExample()
        {
            Console.WriteLine("IocExample");

            var builder = new ContainerBuilder();
            builder.RegisterModule<KeshaModule>();


            builder.RegisterType<ReportService>().As<IReportService>();
            builder.RegisterType<CachedReportService>().As<ICachedReportService>();

            using (var container = builder.Build())
            {
                var cachedReportService = container.Resolve<ICachedReportService>();
                
                var report = cachedReportService.GetReport();
                var report2 = cachedReportService.GetReport();
                Console.WriteLine("Reports are equal? : {0}", report == report2);
            }

            Console.WriteLine();
        }

        private static void PlainExample()
        {
            Console.WriteLine("PlainExample");
            var cacheHolder = new DefaultCacheHolder();
            var cacheFactory = new DefaultCacheFactory();
            var cacheManager = new DefaultCacheManager(cacheHolder, cacheFactory);

            var reportService = new ReportService();
            var cachedReportService = new CachedReportService(cacheManager, reportService);

            var report = cachedReportService.GetReport();
            var report2 = cachedReportService.GetReport();

            Console.WriteLine("Reports are equal? : {0}", report == report2);
            Console.WriteLine();
        }
    }
}
