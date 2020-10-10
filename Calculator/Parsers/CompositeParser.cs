using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator.Parsers
{
    public class CompositeParser : ITokenParser
    {
        private readonly IEnumerable<ITokenParser> _parsers;

        public CompositeParser(params ITokenParser[] parsers) => _parsers = parsers;

        public bool TryParse(string chunk, IToken previousToken, out IToken token)
        {

            foreach (var parser in _parsers)
            {
                if (parser.TryParse(chunk, previousToken, out token))
                {
                    return true;
                }
            }
            token = null;
            return false;
        }
    }
}
