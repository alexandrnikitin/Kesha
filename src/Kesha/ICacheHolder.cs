namespace Kesha
{
    public interface ICacheHolder
    {
        bool TryGet<TCache>(out TCache cache);

        bool TryGet<TScope, TCache>(TScope scope, out TCache cache);

        bool TryAdd<TCache>(TCache cache);

        bool TryAdd<TScope, TCache>(TScope scope, TCache cache);
    }
}