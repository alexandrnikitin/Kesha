namespace Core.Volatile
{
    public interface IInvalidationToken
    {
        bool IsValid { get; }
    }
}