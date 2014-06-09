namespace Core
{
    public interface ICacheFactory
    {
        TCache Create<TCache>();
    }
}