using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator
{
    public interface IExpressionsTreeBuilder
    {
        IExpressionsTree Build(IEnumerable<IToken> tokens);
    }
}
