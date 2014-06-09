namespace Kesha.Volatile
{
    public interface IInvalidationToken
    {
        bool IsValid { get; }
    }
}