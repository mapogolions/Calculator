using System.Collections;
using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator.Test.Fixtures
{
    public class ValidTokensDataSource : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "+", new List<IToken> { Operator.Positive }};
            yield return new object[] { "-", new List<IToken> { Operator.Negative }};
            yield return new object[] { "-(17)",
                new List<IToken> { Operator.Negative, Operator.OpenBracket, new Number<int>(17), Operator.CloseBracket } };
            yield return new object[] { "+17",
                new List<IToken> { Operator.Positive, new Number<int>(17) } };
            yield return new object[] { "1 + 2",
                new List<IToken> { new Number<int>(1), Operator.Plus, new Number<int>(2) } };
            yield return new object[] { "1+-2",
                new List<IToken> { new Number<int>(1), Operator.Plus, Operator.Negative, new Number<int>(2) } };
            yield return new object[] { "((-1))",
                new List<IToken> { Operator.OpenBracket, Operator.OpenBracket, Operator.Negative, new Number<int>(1), Operator.CloseBracket, Operator.CloseBracket } };
            yield return new object[] { "((-1)) + 0.2",
                new List<IToken> { Operator.OpenBracket, Operator.OpenBracket, Operator.Negative, new Number<int>(1), Operator.CloseBracket,
                    Operator.CloseBracket, Operator.Plus, new Number<double>(0.2) } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
