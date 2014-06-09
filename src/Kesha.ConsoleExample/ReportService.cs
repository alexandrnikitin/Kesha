using System;
using System.Threading;

namespace Kesha.ConsoleExample
{
    public class ReportService : IReportService
    {
        public Report GetReport()
        {
            Console.WriteLine("Long time work to create report...");
            Thread.Sleep(3000);
            return new Report();
        }
    }
}