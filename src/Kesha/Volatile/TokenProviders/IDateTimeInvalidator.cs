using System;

namespace Kesha.Volatile.TokenProviders
{
    public interface IDateTimeInvalidator : ITokenProvider
    {
        IToken InvalidateAfter(TimeSpan period);

        IToken InvalidateAtUtc(DateTime dateTimeUtc);
    }
}