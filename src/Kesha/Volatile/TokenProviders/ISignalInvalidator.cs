namespace Kesha.Volatile.TokenProviders
{
    public interface ISignalInvalidator : ITokenProvider
    {
        IToken InvalidateWhen<T>(T signal);

        void Trigger<T>(T signal);
    }
}