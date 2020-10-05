using Xunit;

namespace Calculator.Test
{
    public class ParserTests
    {
        [Fact]
        public void ParseShouldReturnExpressionsTree()
        {
            var parser = new Parser();
            Assert.IsType<ExpressionsTree>(parser.Parse(string.Empty));
        }
    }
}
