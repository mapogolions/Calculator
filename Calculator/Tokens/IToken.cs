namespace Calculator.Tokens
{
    public interface IToken
    {
        int Precedence { get; }
        Associative Associative { get; }
        IToken EnsureIsValid(IToken previousToken);
    }
}
