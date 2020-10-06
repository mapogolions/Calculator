using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator
{
    public interface ITokensTreeBuilder
    {
        ITokensTree Build(IEnumerable<IToken> tokens);
    }
}
