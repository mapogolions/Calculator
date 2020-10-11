using System.Collections.Generic;
using Calculator.Exceptions;
using Calculator.Test.Fixtures;
using Calculator.TokenResolvers;
using Calculator.Tokens;
using Xunit;

namespace Calculator.Test
{
    public class TokenParserTests
    {
        [Theory]
        [ClassData(typeof(InvalidTokensDataSource))]
        public void ParseShouldThrowParseException(string source)
        {
            var tokensResolver = new CompositeTokenResolver(
                new OperatorTokenResolver(OperatorToken.AllAvailable), new NumberTokenResolver());
            var tokensParser = new TokensParser(tokensResolver, OperatorToken.Signs);
            Assert.Throws<ParseException>(() => tokensParser.Parse(source));
        }

        [Theory]
        [ClassData(typeof(ValidTokensDataSource))]
        public void ParseShouldReturnListOfTokens(string source, IEnumerable<IToken> tokens)
        {
            var tokensResolver = new CompositeTokenResolver(
                new OperatorTokenResolver(OperatorToken.AllAvailable), new NumberTokenResolver());
            var tokensParser = new TokensParser(tokensResolver, OperatorToken.Signs);
            Assert.Equal(tokens, tokensParser.Parse(source));
        }

        [Fact]
        public void ParseShouldReturnEmptyListOfTokensWhenSourceContainsWhitespacesOnly()
        {
            var tokensResolver = new CompositeTokenResolver(
                new OperatorTokenResolver(OperatorToken.AllAvailable), new NumberTokenResolver());
            var tokensParser = new TokensParser(tokensResolver, OperatorToken.Signs);
            Assert.Empty(tokensParser.Parse("  \t\n \f"));
        }

        [Fact]
        public void ParseShouldReturnEmptyListOfTokensWhenSourceIsEmptyString()
        {
            var tokenParser = new CompositeTokenResolver(
                new OperatorTokenResolver(OperatorToken.AllAvailable), new NumberTokenResolver());
            var tokensParser = new TokensParser(tokenParser, OperatorToken.Signs);
            Assert.Empty(tokensParser.Parse(string.Empty));
        }
    }
}
