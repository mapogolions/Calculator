using System.Collections.Generic;
using Calculator.Exceptions;
using Calculator.Parsers;
using Calculator.Test.Fixtures;
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
            var tokensResolver = new CompositeResolver(new OperatorResolver(Operator.AllAvailable), new NumberResolver());
            var tokensParser = new TokensParser(tokensResolver, Operator.Signs);
            Assert.Throws<ParseException>(() => tokensParser.Parse(source));
        }

        [Theory]
        [ClassData(typeof(ValidTokensDataSource))]
        public void ParseShouldReturnListOfTokens(string source, IEnumerable<IToken> tokens)
        {
            var tokensResolver = new CompositeResolver(new OperatorResolver(Operator.AllAvailable), new NumberResolver());
            var tokensParser = new TokensParser(tokensResolver, Operator.Signs);
            Assert.Equal(tokens, tokensParser.Parse(source));
        }

        [Fact]
        public void ParseShouldReturnEmptyListOfTokensWhenSourceContainsWhitespacesOnly()
        {
            var tokensResolver = new CompositeResolver(new OperatorResolver(Operator.AllAvailable), new NumberResolver());
            var tokensParser = new TokensParser(tokensResolver, Operator.Signs);
            Assert.Empty(tokensParser.Parse("  \t\n \f"));
        }

        [Fact]
        public void ParseShouldReturnEmptyListOfTokensWhenSourceIsEmptyString()
        {
            var tokenParser = new CompositeResolver(new OperatorResolver(Operator.AllAvailable), new NumberResolver());
            var tokensParser = new TokensParser(tokenParser, Operator.Signs);
            Assert.Empty(tokensParser.Parse(string.Empty));
        }
    }
}
