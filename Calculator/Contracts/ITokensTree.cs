using Calculator.Tokens;

namespace Calculator.Contracts
{
    public interface ITokensTree
    {
        public INode Root { get; set; }
        public ITokensTree Insert(IToken token);
    }

    public interface INode
    {
        public INode Parent { get; set; }
        public INode Left { get; set; }
        public INode Right { get; set; }
        public IToken Token { get; }
    }
}
