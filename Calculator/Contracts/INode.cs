using Calculator.Tokens;

namespace Calculator.Contracts
{
    public interface INode
    {
        INode Parent { get; set; }
        INode Left { get; set; }
        INode Right { get; set; }
        IToken Token { get; }
    }
}
