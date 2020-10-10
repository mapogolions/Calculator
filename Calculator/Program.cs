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
            var parser = new TokensParser(Operator.AllAvailable);
            var tree = new ExpressionsTreeBuilder(parser)
                .Build(snippet);
            Console.WriteLine(tree.Traverse(Traversal.PostOrder));
            Console.WriteLine(tree.Reduce());
        }
    }
}
