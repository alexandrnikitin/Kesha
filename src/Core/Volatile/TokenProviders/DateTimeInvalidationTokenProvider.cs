using System;

namespace Core.Volatile.TokenProviders
{
    public class DateTimeInvalidationTokenProvider : IDateTimeInvalidationTokenProvider
    {
        public IInvalidationToken InvalidateAfter(TimeSpan period)
        {
            return new InvalidationToken(period);
        }

        public IInvalidationToken InvalidateAtUtc(DateTime dateTimeUtc)
        {
            return new InvalidationToken(dateTimeUtc);
        }

        private class InvalidationToken : IInvalidationToken
        {
            private readonly DateTime _invalidateDateTimeUtc;

            public InvalidationToken(DateTime dateTimeUtc)
            {
                _invalidateDateTimeUtc = dateTimeUtc;
            }

            public InvalidationToken(TimeSpan period)
            {
                _invalidateDateTimeUtc = DateTime.UtcNow.Add(period);
            }

            public bool IsValid
            {
                get { return DateTime.UtcNow < _invalidateDateTimeUtc; }
            }
        }
    }
}