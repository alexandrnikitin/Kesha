using System;
using Kesha.Caches;

namespace Kesha.ConsoleExample
{
    public class CachedReportService : IReportService
    {
        private const string CacheKey = "CacheKey";

        private readonly ICacheManager _cacheManager;

        private readonly IReportService _reportService;

        public CachedReportService(ICacheManager cacheManager, IReportService reportService)
        {
            _cacheManager = cacheManager;
            _reportService = reportService;
        }

        public Report GetReport()
        {
            var cache = _cacheManager.Get<ConcurrentDictionaryCache<string, Report>>();
            return cache.GetOrSetItem(CacheKey, () => _reportService.GetReport());
        }
    }
}