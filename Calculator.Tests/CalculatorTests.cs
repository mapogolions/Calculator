using Calculator.Extensions;
using Calculator.TokenResolvers;
using Calculator.Test.Fixtures;
using Calculator.Tokens;
using Xunit;

namespace Calculator.Test
{
    public class CalculatorTests
    {
        [Theory]
        [ClassData(typeof(CalculatorDataSource))]
        public void ShoudEvaluateExpression(string source, double expected)
        {
            var tokensResolver = new CompositeTokenResolver(
                new OperatorTokenResolver(OperatorToken.AllAvailable), new NumberTokenResolver());
            var tokensParser = new TokensParser(tokensResolver, OperatorToken.Signs);
            var actual = new ExpressionsTreeBuilder(tokensParser).Build(source).Reduce();

            Assert.Equal(expected, actual);
        }
    }
}
