using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator
{
    public interface ITokensParser
    {
        public IEnumerable<IToken> Parse(string source);
    }
}
