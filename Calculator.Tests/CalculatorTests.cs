using Calculator.Extensions;
using Calculator.Parsers;
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
            var tokensResolver = new CompositeResolver(new OperatorResolver(Operator.AllAvailable), new NumberResolver());
            var tokensParser = new TokensParser(tokensResolver, Operator.Signs);
            var actual = new ExpressionsTreeBuilder(tokensParser).Build(source).Reduce();

            Assert.Equal(expected, actual);
        }
    }
}
