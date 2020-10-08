using System;
using Calculator.Extensions;
using Calculator.Tokens;

namespace Calculator
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            var snippet = @"(1 + 2) * 3";
            var tree = new ExpressionsTreeBuilder(new TokensParser(Operator.AvailableOperators))
                .Build(snippet);
            Console.WriteLine(tree.Traverse(Traversals.PostOrder));
        }
    }
}
