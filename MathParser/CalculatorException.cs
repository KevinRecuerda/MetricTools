namespace MathParser
{
    using System;

    public class CalculatorException : Exception
    {
        public CalculatorException(string message)
            : base(message)
        {
        }
    }
}