using Calculator.Tokens;
using Xunit;

namespace Calculator.Test
{
    public class ExpressionsTreeTests
    {
        [Fact]
        public void EmptyExpressionsTreeShouldHasNullRoot()
        {
            var tree = new ExpressionsTree();
            Assert.Equal(Operator.OpenBracket, tree.Root.Token);
        }
    }
}
