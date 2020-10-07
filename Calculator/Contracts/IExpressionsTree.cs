using Calculator.Tokens;

namespace Calculator.Contracts
{
    public interface IExpressionsTree
    {
        public INode Root { get; }
        public IExpressionsTree Insert(IToken token);
        public IExpressionsTree ClimbUp(IToken token);
    }

    public interface INode
    {
        public INode Parent { get; set; }
        public INode Left { get; set; }
        public INode Right { get; set; }
        public IToken Token { get; }
    }
}
