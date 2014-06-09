namespace Core
{
    public interface ICacheManager
    {
        TCache Get<TCache>();
    }
}