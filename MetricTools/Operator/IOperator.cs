using System.Collections.Generic;

namespace MetricTools.Operator
{
    public interface IOperator
    {
        double Compute(IEnumerable<double> values);
    }
}