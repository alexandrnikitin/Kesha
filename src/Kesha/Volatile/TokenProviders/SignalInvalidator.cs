using System.Collections.Generic;

namespace Kesha.Volatile.TokenProviders
{
    public class SignalInvalidator : ISignalInvalidator
    {
        private readonly IDictionary<object, Token> _tokens = new Dictionary<object, Token>();

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

        private class Token : IToken
        {
            public Token()
            {
                IsValid = true;
            }

            public bool IsValid { get; private set; }

            public void Trigger()
            {
                IsValid = false;
            }
        }
    }
}