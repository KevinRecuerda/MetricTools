using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace MetricTools.Service
{
    public class FormulaService
    {
        private readonly List<char> operators = new List<char>()
        {
            '(',
            ')',
            '+',
            '-',
            '*',
            '/',
            '%',
            '^'
        }; 

        private readonly Dictionary<char, Func<double, double, double>> operations = new Dictionary<char, Func<double, double, double>>()
        {
            { '+', (x, y) => x + y },
            { '-', (x, y) => x - y },
            { '*', (x, y) => x * y },
            { '/', (x, y) => x / y },
            { '%', (x, y) => x % y },
            { '^', Math.Pow }
        }; 

        public List<string> GetVariables(string formula)
        {
            double unusedResult;
            return formula
                .Replace(" ", string.Empty)
                .Split(this.operators.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .Where(x => !double.TryParse(x, NumberStyles.Number, CultureInfo.InvariantCulture, out unusedResult))
                .ToList();
        }

        public double Evaluate(string formula, Dictionary<string, double> variableValues = null)
        {
            // TODO
            return 0;
        }

        private double Evaluate(List<Token> toekns, Dictionary<string, double> variableValues = null)
        {
            // TODO
            return 0;
        }
    }

    internal class Token
    {
    }
}