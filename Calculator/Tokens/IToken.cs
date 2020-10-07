namespace Calculator.Tokens
{
    public interface IToken
    {
        int Precedence { get; }
        IToken EnsureIsValid(IToken previousToken);
    }
}
