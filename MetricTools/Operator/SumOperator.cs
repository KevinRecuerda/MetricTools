using System.Collections.Generic;
using System.Linq;

namespace MetricTools.Operator
{
    public class SumOperator : IOperator
    {
        public double Compute(IEnumerable<double> values)
        {
            return values.Sum();
        }
    }
}