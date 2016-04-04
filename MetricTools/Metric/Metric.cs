namespace MetricTools.Metric
{
    public abstract class Metric
    {
        public string MetricSetId { get; set; }
        public string Id { get; set; }
        public string Formula { get; set; }
        public string Filter { get; set; }

        public bool IsValidFormula { get; set; }
        public bool IsValidFilter { get; set; }

        public abstract void Compute();
    }
}