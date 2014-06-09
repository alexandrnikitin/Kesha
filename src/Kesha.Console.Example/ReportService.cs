using System.Threading;

namespace Kesha.Console.Example
{
    public class ReportService : IReportService
    {
        public Report GetReport()
        {
            System.Console.WriteLine("Long time work to create report...");
            Thread.Sleep(1000);
            return new Report();
        }
    }
}