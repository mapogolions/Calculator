using System.Text;
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
            if (token.Associative is Associative.None) return CurrentNode;
            var currentNode = CurrentNode;
            while (currentNode.Token.Precedence >= token.Precedence)
                currentNode = currentNode.Parent;
            return currentNode;
        }

        public override string ToString()
        {
            static StringBuilder InOrder(INode node, StringBuilder acc)
            {
                if (node is null) return acc;
                InOrder(node.Left, acc);
                acc.Append(node.Token);
                InOrder(node.Right, acc);
                return acc;
            }
            return InOrder(Root, new StringBuilder()).ToString();
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
