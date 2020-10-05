using Xunit;

namespace Calculator.Test
{
    public class ExpressionsTreeTests
    {
        [Fact]
        public void EmptyExpressionsTreeShouldHasNullRoot()
        {
            var tree = new ExpressionsTree();
            Assert.Null(tree.Root);
        }
    }
}
