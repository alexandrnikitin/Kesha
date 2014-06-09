using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kesha.Default;

namespace Kesha.Console.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var cacheHolder = new DefaultCacheHolder();
            var cacheFactory = new DefaultCacheFactory();
            var cacheManager = new DefaultCacheManager(cacheHolder, cacheFactory);
            
            var reportService = new ReportService();
            var cachedReportService = new CachedReportService(cacheManager, reportService);

            System.Console.WriteLine("Getting report...");
            var report = cachedReportService.GetReport();
            System.Console.WriteLine("Getting report...");
            var report2 = cachedReportService.GetReport();
            System.Console.WriteLine("Reports are equal? : {0}", report == report2);
            System.Console.WriteLine("Finished");
            System.Console.ReadKey();
        }
    }
}
