namespace Kesha.Volatile.TokenProviders
{
    public interface ISignalInvalidator : ITokenProvider
    {
        void Trigger<T>(T signal);

        IToken InvalidateWhen<T>(T signal);
    }
}