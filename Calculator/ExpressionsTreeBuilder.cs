using Calculator.Contracts;

namespace Calculator
{
    public class ExpressionsTreeBuilder : IExpressionsTreeBuilder
    {
        private readonly ITokensParser _parser;

        public ExpressionsTreeBuilder(ITokensParser parser)
        {
            _parser = parser;
        }
        public IExpressionsTree Build(string source)
        {
            var tree = new ExpressionsTree();
            foreach (var token in _parser.Parse(source))
            {
                tree.Insert(token);
            }
            return tree;
        }
    }
}
