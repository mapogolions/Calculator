using System.Collections;
using System.Collections.Generic;

namespace Calculator.Test.Fixtures
{
    public class InvalidTokensDataSource : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "+" };
            yield return new object[] { "-" };
            yield return new object[] { "*" };
            yield return new object[] { "/" };
            yield return new object[] { ")" };
            yield return new object[] { "-)" };
            yield return new object[] { "()" };
            yield return new object[] { "*)" };
            yield return new object[] { "5 + * 5" };
            yield return new object[] { "6 + - / 5"};
            yield return new object[] { "(^"};
            yield return new object[] { "4(" };
            yield return new object[] { "3 + 3)" };
            yield return new object[] { "(3 + 3" };
            yield return new object[] { "(2))" };
            yield return new object[] { "2 + 3 +" };
            yield return new object[] { "2 + 3 / + -" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
