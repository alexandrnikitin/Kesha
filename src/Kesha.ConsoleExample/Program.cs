using System;
using Kesha.Default;

namespace Kesha.ConsoleExample
{
    class Program
    {
        static void Main()
        {
            var cacheHolder = new DefaultCacheHolder();
            var cacheFactory = new DefaultCacheFactory();
            var cacheManager = new DefaultCacheManager(cacheHolder, cacheFactory);
            
            var reportService = new ReportService();
            var cachedReportService = new CachedReportService(cacheManager, reportService);

            Console.WriteLine("Getting report...");
            var report = cachedReportService.GetReport();
            
            Console.WriteLine("Getting report...");
            var report2 = cachedReportService.GetReport();
            
            Console.WriteLine("Reports are equal? : {0}", report == report2);
            
            
            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
