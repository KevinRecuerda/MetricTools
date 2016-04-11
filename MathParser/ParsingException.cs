namespace MathParser
{
    using System;

    public class ParsingException : Exception
    {
        public ParsingException(string message)
            : base(message)
        {
        }
    }
}