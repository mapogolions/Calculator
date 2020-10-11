using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator.TokenResolvers
{
    public class CompositeTokenResolver : ITokensResolver
    {
        private readonly IEnumerable<ITokensResolver> _tokenResolvers;

        public CompositeTokenResolver(params ITokensResolver[] tokenResolvers) => _tokenResolvers = tokenResolvers;

        public bool TryResolve(string chunk, IToken previousToken, out IToken token)
        {

            foreach (var tokenResolver in _tokenResolvers)
            {
                if (tokenResolver.TryResolve(chunk, previousToken, out token))
                {
                    return true;
                }
            }
            token = null;
            return false;
        }
    }
}
