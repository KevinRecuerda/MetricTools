using System.Collections.Generic;
using System.Linq;

namespace MetricTools.Operator
{
    public class MinOperator : IOperator
    {
        public double Compute(IEnumerable<double> values)
        {
            return values.Min();
        }
    }
}