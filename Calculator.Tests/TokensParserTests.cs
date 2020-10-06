using System;
using System.Collections.Generic;
using Calculator.Test.Fixtures;
using Calculator.Tokens;
using Xunit;

namespace Calculator.Test
{
    public class TokenParserTests
    {
        [Theory]
        [ClassData(typeof(TokensDataSource))]
        public void ParseShouldReturnListOfTokens(string source, IEnumerable<IToken> tokens)
        {
            var parser = new TokensParser(Operator.AvailableOperators);
            Assert.Equal(tokens, parser.Parse(source));
        }

        [Fact]
        public void ParseShouldThrowInvalidOperationExceptionWhenSourceIsInvalid()
        {
            var parser = new TokensParser(Operator.AvailableOperators);
            Assert.Throws<InvalidOperationException>(() => parser.Parse("34.45 45"));
        }

        [Theory]
        [ClassData(typeof(NumberTokensDataSource))]
        public void ParseShouldReturnListOfNumberTokens(string source, IEnumerable<IToken> tokens)
        {
            var parser = new TokensParser(Operator.AvailableOperators);
            Assert.Equal(tokens, parser.Parse(source));
        }

        [Theory]
        [ClassData(typeof(OperatorTokensDataSource))]
        public void ParseShouldReturnListOfOperatorTokens(string source, IEnumerable<IToken> tokens)
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
