using System;
using Calculator.Contracts;
using Calculator.Tokens;

namespace Calculator
{
    public class ExpressionsTree : IExpressionsTree
    {
        public INode Root { get; set; }

        public IExpressionsTree Insert(IToken token)
        {
            if (Root is { }) return this;
            if (token is Operator op && op.Kind is OperatorKinds.Binary)
                throw new InvalidOperationException();
            Root = new Node(token);
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
