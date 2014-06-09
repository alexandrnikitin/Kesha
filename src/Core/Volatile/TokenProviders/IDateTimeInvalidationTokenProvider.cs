using System;

namespace Core.Volatile.TokenProviders
{
    public interface IDateTimeInvalidationTokenProvider : IInvalidationTokenProvider
    {
        IInvalidationToken InvalidateAfter(TimeSpan period);

        IInvalidationToken InvalidateAtUtc(DateTime dateTimeUtc);
    }
}