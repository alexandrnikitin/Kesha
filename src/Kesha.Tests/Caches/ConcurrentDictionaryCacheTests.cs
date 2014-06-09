using Kesha.Caches;
using TestStack.BDDfy;
using TestStack.BDDfy.Scanners.StepScanners.Fluent;
using Xunit;

namespace Kesha.Tests.Caches
{
    public class ConcurrentDictionaryCacheTests
    {
        private readonly ConcurrentDictionaryCache<string, object> _sut;

        public ConcurrentDictionaryCacheTests()
        {
            _sut = new ConcurrentDictionaryCache<string, object>();
        }

        public class TryGetItemTests : ConcurrentDictionaryCacheTests
        {
            private bool _ret;
            private object _retItem;

            [Fact]
            public void GetsCachedItem()
            {
                const string cachekey = "CacheKey";
                var cachedItem = new object();

                this.Given(x => x.CacheContains(cachekey, cachedItem))
                    .When(x => x.TryingToGetItem(cachekey))
                    .Then(x => x.ShouldReturn(true))
                    .And(x => x.ItemShouldBe(cachedItem))
                    .BDDfy();
            }

            [Fact]
            public void DoesNotGetItem()
            {
                this.Given(x => x.CacheIsEmpty())
                    .When(x => x.TryingToGetItem("AnyKey"))
                    .Then(x => x.ShouldReturn(false))
                    .BDDfy();
            }

            private void CacheIsEmpty()
            {
            }

            private void ItemShouldBe(object expectedItem)
            {
                Assert.Equal(expectedItem, _retItem);
            }

            private void ShouldReturn(bool returnExpected)
            {
                Assert.Equal(returnExpected, _ret);
            }

            private void CacheContains(string key, object item)
            {
                _sut.SetItem(key, item);
            }

            private void TryingToGetItem(string key)
            {
                _ret = _sut.TryGetItem(key, out _retItem);
            }
        }
    }
}