using Calculator.Tokens;

namespace Calculator.Contracts
{
    public interface IExpressionsTree
    {
        INode Root { get; }
        IExpressionsTree Insert(IToken token);
        INode ClimbUp(IToken token);
    }

    public interface INode
    {
        INode Parent { get; set; }
        INode Left { get; set; }
        INode Right { get; set; }
        IToken Token { get; }
    }
}
