using Calculator.Tokens;

namespace Calculator
{
    public class ExpressionsTree : IExpressionsTree
    {
        public INode Root { get; set; }
        public IExpressionsTree Insert(IToken token)
        {
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
