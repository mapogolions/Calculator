using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator.Contracts
{
    public interface IExpressionsTreeBuilder
    {
        IExpressionsTree Build(IEnumerable<IToken> tokens);
    }
}
