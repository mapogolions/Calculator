using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator.Contracts
{
    public interface ITokensParser
    {
        IEnumerable<IToken> Parse(string source);
    }
}
