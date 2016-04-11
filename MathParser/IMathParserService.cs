namespace MathParser
{
    using System.Collections.Generic;

    public interface IMathParserService
    {
        Expression Parse(string expression);

        T Evaluate<T>(Expression expression, Dictionary<string, object> parameters = null);
    }
}