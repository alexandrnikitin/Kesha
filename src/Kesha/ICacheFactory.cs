namespace Kesha
{
    public interface ICacheFactory
    {
        TCache Create<TCache>();
    }
}