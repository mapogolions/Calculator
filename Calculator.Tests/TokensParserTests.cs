using System.Collections.Generic;
using Calculator.Exceptions;
using Calculator.Test.Fixtures;
using Calculator.Tokens;
using Xunit;

namespace Calculator.Test
{
    public class TokenParserTests
    {
        [Theory]
        [ClassData(typeof(InvalidTokensDataSource))]
        public void ParseShouldThrowParserExceptionWithMessage(string source)
        {
            var parser = new TokensParser(Operator.AvailableOperators);
            Assert.Throws<ParseException>(() => parser.Parse(source));
        }

        [Theory]
        [ClassData(typeof(ValidTokensDataSource))]
        public void ParseShouldReturnListOfTokens(string source, IEnumerable<IToken> tokens)
        {
            var parser = new TokensParser(Operator.AvailableOperators);
            Assert.Equal(tokens, parser.Parse(source));
        }

        [Fact]
        public void ParseShouldReturnEmptyListOfTokensWhenSourceContainsWhitespacesOnly()
        {
            var parser = new TokensParser(Operator.AvailableOperators);
            Assert.Empty(parser.Parse("  \t\n \f"));
        }

        [Fact]
        public void ParseShouldReturnEmptyListOfTokensWhenSourceIsEmptyString()
        {
            var parser = new TokensParser(Operator.AvailableOperators);
            Assert.Empty(parser.Parse(string.Empty));
        }
    }
}
