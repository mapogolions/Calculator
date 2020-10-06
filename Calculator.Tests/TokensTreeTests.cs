using Xunit;

namespace Calculator.Test
{
    public class TokensTreeTests
    {
        [Fact]
        public void EmptyExpressionsTreeShouldHasNullRoot()
        {
            var tree = new TokensTree();
            Assert.Null(tree.Root);
        }
    }
}
