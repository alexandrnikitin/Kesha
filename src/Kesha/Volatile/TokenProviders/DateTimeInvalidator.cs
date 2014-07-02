using System;

namespace Kesha.Volatile.TokenProviders
{
    public class DateTimeInvalidator : IDateTimeInvalidator
    {
        public IToken InvalidateAfter(TimeSpan period)
        {
            return new Token(period);
        }

        public IToken InvalidateAtUtc(DateTime dateTimeUtc)
        {
            return new Token(dateTimeUtc);
        }

        private class Token : IToken
        {
            private readonly DateTime _invalidateDateTimeUtc;

            public Token(DateTime dateTimeUtc)
            {
                _invalidateDateTimeUtc = dateTimeUtc;
            }

            public Token(TimeSpan period)
            {
                _invalidateDateTimeUtc = DateTime.UtcNow.Add(period);
            }

            public bool IsValid
            {
                get
                {
                    return DateTime.UtcNow < _invalidateDateTimeUtc;
                }
            }
        }
    }
}