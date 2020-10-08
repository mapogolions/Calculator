using System.Collections;
using System.Collections.Generic;
using Calculator.Tokens;

namespace Calculator.Test.Fixtures
{
    public class ClimbUpLeftAssocOperatorsDataSource : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new ExpressionsTree()
                    .Insert(new Number<int>(1))
                    .Insert(Operator.Plus)
                    .Insert(new Number<double>(34.3)),
                "1+34.3",
            };

            yield return new object[]
            {
                new ExpressionsTree()
                    .Insert(Operator.OpenBracket)
                    .Insert(new Number<int>(1))
                    .Insert(Operator.Plus)
                    .Insert(new Number<int>(2))
                    .Insert(Operator.Minus)
                    .Insert(new Number<int>(3))
                    .Insert(Operator.CloseBracket),
                "(1+2-3)",
            };

            yield return new object[]
            {
                new ExpressionsTree()
                    .Insert(Operator.OpenBracket)
                    .Insert(new Number<int>(1))
                    .Insert(Operator.Plus)
                    .Insert(new Number<int>(2))
                    .Insert(Operator.Times)
                    .Insert(new Number<double>(3.1))
                    .Insert(Operator.CloseBracket),
                "(1+2*3.1)",
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
