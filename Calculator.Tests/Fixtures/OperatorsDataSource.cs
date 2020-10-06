using System.Collections;
using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator.Test.Fixtures
{
    public class OperatorsDataSource : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "+  ", new List<IToken> {Operator.Positive}};
            yield return new object[] { "(+", new List<IToken> {Operator.OpenBracket, Operator.Positive}};
            yield return new object[] { ")+", new List<IToken> {Operator.CloseBracket, Operator.Plus}};
            yield return new object[] { "  -\f", new List<IToken> {Operator.Negative}};
            yield return new object[] { "(-", new List<IToken> {Operator.OpenBracket, Operator.Negative}};
            yield return new object[] { ")-", new List<IToken> {Operator.CloseBracket, Operator.Minus}};
            yield return new object[] { "*", new List<IToken> {Operator.Times}};
            yield return new object[] { " /\t", new List<IToken> {Operator.Divide}};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
