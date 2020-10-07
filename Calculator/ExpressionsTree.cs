using System;
using Calculator.Contracts;
using Calculator.Tokens;

namespace Calculator
{
    public class ExpressionsTree : IExpressionsTree
    {
        private INode _root;
        public INode Root
        {
            get => _root;
            private set
            {
                if (_root is null && value.Token is BinaryOperator _)
                    throw new InvalidOperationException("Before binary operator must be operand");
                if (Equals(value.Token, Operator.CloseBracket))
                    throw new InvalidOperationException("Close bracket can't be root");
                _root = value;
            }
        }

        private INode _currentNode;

        public INode CurrentNode
        {
            get => _currentNode;
            private set
            {
                if (_currentNode is null)
                {
                    _currentNode = value;
                    return;
                }
            }
        }

        public IExpressionsTree Insert(IToken token)
        {
            var node = new Node(token);
            if (Root is null)
            {
                Root = CurrentNode = node;
            }
            return this;
        }

        public IExpressionsTree ClimbUp(IToken token)
        {
            throw new NotImplementedException();
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
