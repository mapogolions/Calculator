using Calculator.Contracts;
using Calculator.Tokens;
using Calculator.Extensions;
using System.Linq;

namespace Calculator
{
    public class ExpressionsTree : IExpressionsTree
    {
        public INode Root { get; private set; }

        public INode CurrentNode { get; private set; }

        public ExpressionsTree()
        {
            Root = CurrentNode = new Node(Operator.OpenBracket);
        }

        public IExpressionsTree Insert(IToken token)
        {
            CurrentNode = ClimbUp(token);
            var node = new Node(token) { Left = CurrentNode.Right, Parent = CurrentNode };
            if (CurrentNode.Right != null) CurrentNode.Right.Parent = node;
            CurrentNode.Right = node;
            CurrentNode = node;
            return this;
        }

        private INode ClimbUp(IToken token)
        {
            if (token.Associative is Associative.None) return CurrentNode;
            var currentNode = CurrentNode;
            if (token.Associative is Associative.Left)
            {
                while (currentNode.Token.Precedence >= token.Precedence)
                    currentNode = currentNode.Parent;
            }
            else
            {
                while (currentNode.Token.Precedence > token.Precedence)
                    currentNode = currentNode.Parent;
            }
            return currentNode;
        }

        public override string ToString() =>
            string.Join(string.Empty, this.InOrder().Skip(1).Select(x => x.Token));

        private class Node : INode
        {
            public INode Parent { get; set; }
            public INode Left { get; set; }
            public INode Right { get; set; }

            public Node(IToken token)
            {
                Token = token;
            }
            public IToken Token { get;  }
        }
    }
}
