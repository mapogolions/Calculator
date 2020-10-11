using Calculator.Tokens;

namespace Calculator.Contracts
{
    public interface IExpressionsTree
    {
        INode Root { get; }
        IExpressionsTree Insert(IToken token);
    }
}
