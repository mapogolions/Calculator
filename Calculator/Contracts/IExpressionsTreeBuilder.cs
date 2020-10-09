namespace Calculator.Contracts
{
    public interface IExpressionsTreeBuilder
    {
        IExpressionsTree Build(string source);
    }
}
