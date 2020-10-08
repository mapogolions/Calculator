using Calculator.Contracts;
using Calculator.Test.Fixtures;
using Calculator.Tokens;
using Xunit;

namespace Calculator.Test
{
    public class ExpressionsTreeTests
    {
        [Theory]
        [ClassData(typeof(ClimbUpLeftAssocOperatorsDataSource))]
        public void ShouldClimbUpLeftAssociativeOperators(IExpressionsTree tree, string expected)
        {
            Assert.Equal(expected, tree.ToString());
        }

        [Fact]
        public void ShouldSkipClimbUpForNoneAssociativeTokens()
        {
            var tree = new ExpressionsTree()
                .Insert(Operator.OpenBracket)
                .Insert(new Number<int>(1));

            Assert.Equal("(1", tree.ToString());
        }

        [Fact]
        public void ShouldReturnOpenBracketWhenTreeIsEmpty()
        {
            var tree = new ExpressionsTree();
            Assert.Equal(string.Empty, tree.ToString());
        }

        [Fact]
        public void EmptyExpressionsTreeShouldHasNullRoot()
        {
            var tree = new ExpressionsTree();
            Assert.Equal(Operator.OpenBracket, tree.Root.Token);
        }
    }
}
