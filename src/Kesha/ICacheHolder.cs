namespace Kesha
{
    public interface ICacheHolder
    {
        bool TryGet<TCache>(out TCache cache);

        bool TryGet<TScopeKey, TCache>(TScopeKey scopeKey, out TCache cache);

        bool TryAdd<TCache>(TCache cache);

        bool TryAdd<TScopeKey, TCache>(TScopeKey scopeKey, TCache cache);
    }
}