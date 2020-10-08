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
            Assert.Equal(expectedInOrder, tree.Traverse(Traversals.InOrder));
            Assert.Equal(expectedPostOrder, tree.Traverse(Traversals.PostOrder));
        }

        [Theory]
        [ClassData(typeof(ClimbUpLeftAssocOperatorsDataSource))]
        public void ShouldClimbUpLeftAssociativeOperators(IExpressionsTree tree,
            string expectedInOrder, string expectedPostOrder)
        {
            Assert.Equal(expectedInOrder, tree.Traverse(Traversals.InOrder));
            Assert.Equal(expectedPostOrder, tree.Traverse(Traversals.PostOrder));
        }

        [Fact]
        public void ShouldSkipClimbUpForNoneAssociativeTokens()
        {
            var tree = new ExpressionsTree()
                .Insert(Operator.OpenBracket)
                .Insert(new Number<int>(1));

            Assert.Equal("1", tree.Traverse(Traversals.InOrder));
        }

        [Fact]
        public void ShouldReturnOpenBracketWhenTreeIsEmpty()
        {
            var tree = new ExpressionsTree();
            Assert.Equal(string.Empty, tree.Traverse(Traversals.InOrder));
        }

        [Fact]
        public void EmptyExpressionsTreeShouldHasNullRoot()
        {
            var tree = new ExpressionsTree();
            Assert.Equal(Operator.OpenBracket, tree.Root.Token);
        }
    }
}
