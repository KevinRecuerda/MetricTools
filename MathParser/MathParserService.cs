namespace MathParser
{
    using System.Collections.Generic;

    public class MathParserService : IMathParserService
    {
        public Expression Parse(string expression)
        {
            return new Expression(expression);
        }

        public T Evaluate<T>(Expression expression, Dictionary<string, object> parameters = null)
        {
            return expression.Evaluate<T>(parameters);
        }
    }
}