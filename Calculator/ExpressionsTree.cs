using Calculator.Contracts;
using Calculator.Tokens;

namespace Calculator
{
    public class ExpressionsTree : IExpressionsTree
    {
        public INode Root { get; private set; }

        public INode CurrentNode { get; private set; }

        public IExpressionsTree Insert(IToken token)
        {
            if (Root is null)
            {
                Root = CurrentNode = new Node(token);
                return this;
            }
            if (CurrentNode.Token.Precedence >= token.Precedence)
            {
                return ClimbUp(token);
            }
            CurrentNode.Right = new Node(token) { Parent = CurrentNode };
            return this;
        }

        private IExpressionsTree ClimbUp(IToken token)
        {
            if (token.Associative != Associative.Left) return this;
            var currentNode = CurrentNode;
            CurrentNode = new Node(token)
            {
                Parent = currentNode.Parent,
                Left = currentNode
            };
            return this;
        }

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
