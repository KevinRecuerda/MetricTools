namespace MathParser
{
    using System;

    public class EvaluationException : Exception
    {
        public EvaluationException(string message)
            : base(message)
        {
        }
    }
}