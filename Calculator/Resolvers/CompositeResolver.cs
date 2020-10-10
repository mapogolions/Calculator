using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator.Parsers
{
    public class CompositeResolver : ITokensResolver
    {
        private readonly IEnumerable<ITokensResolver> _parsers;

        public CompositeResolver(params ITokensResolver[] parsers) => _parsers = parsers;

        public bool TryResolve(string chunk, IToken previousToken, out IToken token)
        {

            foreach (var parser in _parsers)
            {
                if (parser.TryResolve(chunk, previousToken, out token))
                {
                    return true;
                }
            }
            token = null;
            return false;
        }
    }
}
