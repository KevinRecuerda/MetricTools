using System.Collections.Generic;

namespace MetricTools.Service
{
    public interface IMetricService
    {
        void Compute(IEnumerable<Metric.Metric> metrics, IEnumerable<Position.Position> positions);
    }
}