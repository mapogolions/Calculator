using System;
using Calculator.Extensions;
using Calculator.TokenResolvers;
using Calculator.Tokens;

namespace Calculator
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            var snippet = "-(2 ^ 2 ^ 3)";
            var tokensResolver = new CompositeTokenResolver(
                new OperatorTokenResolver(OperatorToken.AllAvailable), new NumberTokenResolver());
            var tokensParser = new TokensParser(tokensResolver, OperatorToken.Signs);
            var result = new ExpressionsTreeBuilder(tokensParser).Build(snippet).Reduce();
            Console.WriteLine(result);
        }
    }
}
