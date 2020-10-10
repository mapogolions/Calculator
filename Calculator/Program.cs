using System;
using Calculator.Extensions;
using Calculator.Parsers;
using Calculator.Tokens;

namespace Calculator
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            var snippet = "-(2 ^ 2 ^ 3)";
            var tokensResolver = new CompositeResolver(new OperatorResolver(Operator.AllAvailable), new NumberResolver());
            var tokensParser = new TokensParser(tokensResolver, Operator.Signs);
            var result = new ExpressionsTreeBuilder(tokensParser).Build(snippet).Reduce();
            Console.WriteLine(result);
        }
    }
}
