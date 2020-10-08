using Calculator.Contracts;
using Calculator.Tokens;

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

        public INode ClimbUp(IToken token)
        {
            var currentNode = CurrentNode;
            while (currentNode.Token.Precedence >= token.Precedence)
                currentNode = currentNode.Parent;
            return currentNode;
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
