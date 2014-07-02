namespace Kesha
{
    public interface ICacheManager
    {
        TCache Get<TCache>();

        TCache Get<TCache, TScope>(TScope scope);
    }
}