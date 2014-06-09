using System.Collections.Generic;

namespace Kesha.Volatile.TokenProviders
{
    public class SignalInvalidationTokenProvider : ISignalInvalidationTokenProvider
    {
        private readonly IDictionary<object, InvalidationToken> _tokens = new Dictionary<object, InvalidationToken>();

        public void Trigger<T>(T signal)
        {
            lock (_tokens)
            {
                InvalidationToken token;
                if (_tokens.TryGetValue(signal, out token))
                {
                    _tokens.Remove(signal);
                    token.Trigger();
                }
            }
        }

        public IInvalidationToken InvalidateWhen<T>(T signal)
        {
            lock (_tokens)
            {
                InvalidationToken token;
                if (!_tokens.TryGetValue(signal, out token))
                {
                    token = new InvalidationToken();
                    _tokens[signal] = token;
                }

                return token;
            }
        }

        private class InvalidationToken : IInvalidationToken
        {
            #region Constructors and Destructors

            public InvalidationToken()
            {
                IsValid = true;
            }

            #endregion

            #region Public Properties

            public bool IsValid { get; private set; }

            #endregion

            #region Public Methods and Operators

            public void Trigger()
            {
                IsValid = false;
            }

            #endregion
        }
    }
}