using Calculator.Contracts;
using Calculator.Extensions;
using Calculator.Test.Fixtures;
using Calculator.Tokens;
using Xunit;

namespace Calculator.Test
{
    public class ExpressionsTreeTests
    {
        [Theory]
        [ClassData(typeof(ClimbUpRightAssocOperatorsDataSource))]
        public void ShouldClimbUpRighAssociativeOperators(IExpressionsTree tree,
            string expectedInOrder, string expectedPostOrder)
        {
            Assert.Equal(expectedInOrder, tree.Traverse(Traversal.InOrder));
            Assert.Equal(expectedPostOrder, tree.Traverse(Traversal.PostOrder));
        }

        [Theory]
        [ClassData(typeof(ClimbUpLeftAssocOperatorsDataSource))]
        public void ShouldClimbUpLeftAssociativeOperators(IExpressionsTree tree,
            string expectedInOrder, string expectedPostOrder)
        {
            Assert.Equal(expectedInOrder, tree.Traverse(Traversal.InOrder));
            Assert.Equal(expectedPostOrder, tree.Traverse(Traversal.PostOrder));
        }

        [Fact]
        public void ShouldSkipClimbUpForNoneAssociativeTokens()
        {
            var tree = new ExpressionsTree()
                .Insert(OperatorToken.OpenBracket)
                .Insert(new NumberToken<int>(1));

            Assert.Equal("1", tree.Traverse(Traversal.InOrder));
        }

        [Fact]
        public void ShouldReturnOpenBracketWhenTreeIsEmpty()
        {
            var tree = new ExpressionsTree();
            Assert.Equal(string.Empty, tree.Traverse(Traversal.InOrder));
        }

        [Fact]
        public void EmptyExpressionsTreeShouldHasNullRoot()
        {
            var tree = new ExpressionsTree();
            Assert.Equal(OperatorToken.OpenBracket, tree.Root.Token);
        }
    }
}
