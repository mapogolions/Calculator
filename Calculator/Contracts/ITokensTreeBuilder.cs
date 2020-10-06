using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator.Contracts
{
    public interface ITokensTreeBuilder
    {
        ITokensTree Build(IEnumerable<IToken> tokens);
    }
}
