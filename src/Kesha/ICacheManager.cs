namespace Kesha
{
    public interface ICacheManager
    {
        TCache Get<TCache>();
    }
}