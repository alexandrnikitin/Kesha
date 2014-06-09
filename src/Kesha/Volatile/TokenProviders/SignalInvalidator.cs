using System.Collections.Generic;

namespace Kesha.Volatile.TokenProviders
{
    public class SignalInvalidator : ISignalInvalidator
    {
        private readonly IDictionary<object, Token> _tokens = new Dictionary<object, Token>();

        public void Trigger<T>(T signal)
        {
            lock (_tokens)
            {
                Token token;
                if (_tokens.TryGetValue(signal, out token))
                {
                    _tokens.Remove(signal);
                    token.Trigger();
                }
            }
        }

        public IToken InvalidateWhen<T>(T signal)
        {
            lock (_tokens)
            {
                Token token;
                if (!_tokens.TryGetValue(signal, out token))
                {
                    token = new Token();
                    _tokens[signal] = token;
                }

                return token;
            }
        }

        private class Token : IToken
        {
            #region Constructors and Destructors

            public Token()
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