using System.Collections;
using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator.Test.Fixtures
{
    public class NumberTokensDataSource : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "17", new List<IToken> { new Number<int>(17) } };
            yield return new object[] { "16.7", new List<IToken> { new Number<double>(16.7) } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
