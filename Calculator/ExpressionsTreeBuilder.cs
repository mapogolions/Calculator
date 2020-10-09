using System.Linq;
using Calculator.Contracts;
using Calculator.Tokens;

namespace Calculator
{
    public class ExpressionsTreeBuilder : IExpressionsTreeBuilder
    {
        private readonly ITokensParser _parser;

        public ExpressionsTreeBuilder(ITokensParser parser) => _parser = parser;

        public IExpressionsTree Build(string source) => _parser.Parse(source)
            .Aggregate<IToken, IExpressionsTree>(new ExpressionsTree(), (tree, token) => tree.Insert(token));
    }
}
