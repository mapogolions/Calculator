using System;
using Calculator.Tokens;

namespace Calculator
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            var snippet = @"-(-2)";
            var tree = new ExpressionsTreeBuilder(new TokensParser(Operator.AvailableOperators))
                .Build(snippet);
            Console.WriteLine(tree.ToString());
        }
    }
}
