using System.Collections.Generic;

namespace MetricTools.Service
{
    public class MetricService : IMetricService
    {
        public void Compute(IEnumerable<Metric.Metric> metrics, IEnumerable<Position.Position> positions)
        {
            // Création de l'arbre !!!

            // 0) Création des partitions à partir des positions
            // -> IPartitionService ??
            var partitions = this.CreatePartitions(positions);

            // 1) Calcul extension metrics

            // 2) Calcul simple metrics

            // 3) Calcul derivated metrics
        }

        private Dictionary<string, List<string>> CreatePartitions(IEnumerable<Position.Position> positions)
        {
            throw new System.NotImplementedException();
        }
    }
}