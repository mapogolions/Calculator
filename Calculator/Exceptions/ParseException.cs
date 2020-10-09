using System;

namespace Calculator.Exceptions
{
    public class ParseException : Exception
    {
        public ParseException(string errorMessage) : base(errorMessage) { }
    }
}
