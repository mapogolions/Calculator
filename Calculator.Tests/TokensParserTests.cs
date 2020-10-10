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
            var tokenParser = new CompositeParser(new OperatorParser(Operator.AllAvailable), new NumberParser());
            var parser = new TokensParser(tokenParser, Operator.AllAvailable);
            Assert.Throws<ParseException>(() => parser.Parse(source));
        }

        [Theory]
        [ClassData(typeof(ValidTokensDataSource))]
        public void ParseShouldReturnListOfTokens(string source, IEnumerable<IToken> tokens)
        {
            var tokenParser = new CompositeParser(new OperatorParser(Operator.AllAvailable), new NumberParser());
            var parser = new TokensParser(tokenParser, Operator.AllAvailable);
            Assert.Equal(tokens, parser.Parse(source));
        }

        [Fact]
        public void ParseShouldReturnEmptyListOfTokensWhenSourceContainsWhitespacesOnly()
        {
            var tokenParser = new CompositeParser(new OperatorParser(Operator.AllAvailable), new NumberParser());
            var parser = new TokensParser(tokenParser, Operator.AllAvailable);
            Assert.Empty(parser.Parse("  \t\n \f"));
        }

        [Fact]
        public void ParseShouldReturnEmptyListOfTokensWhenSourceIsEmptyString()
        {
            var tokenParser = new CompositeParser(new OperatorParser(Operator.AllAvailable), new NumberParser());
            var parser = new TokensParser(tokenParser, Operator.AllAvailable);
            Assert.Empty(parser.Parse(string.Empty));
        }
    }
}
