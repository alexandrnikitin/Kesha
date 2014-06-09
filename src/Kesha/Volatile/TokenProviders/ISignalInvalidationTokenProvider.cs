namespace Kesha.Volatile.TokenProviders
{
    public interface ISignalInvalidationTokenProvider : IInvalidationTokenProvider
    {
        void Trigger<T>(T signal);

        IInvalidationToken InvalidateWhen<T>(T signal);
    }
}