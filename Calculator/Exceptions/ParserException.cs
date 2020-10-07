using System;

namespace Calculator.Exceptions
{
    public class ParserException : Exception
    {
        public ParserException(string errorMessage) : base(errorMessage) { }
    }
}
