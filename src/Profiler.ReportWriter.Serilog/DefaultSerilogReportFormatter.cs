using System;
using System.Collections.Generic;
using System.Linq;

namespace Profiler
{
    internal class DefaultSerilogReportFormatter : ISerilogReportFormatter
    {
        private readonly IEqualityComparer<string[]> _chainEqualityComparer = new ChainEqualityComparer();

        private readonly string _messageTemplate = "{chain} {count} {elapsedMs}";

        private readonly Func<string[], string> _formatChain = chain => string.Join(", ", chain);

        public IEnumerable<(string messageTemplate, object[] propertyValues)> Format(IEnumerable<ISectionMetrics> metricsCollection)
        {
            var aggregatedMetrics = metricsCollection
                .GroupBy(
                    keySelector: m => m.Chain,
                    elementSelector: m => m,
                    resultSelector: (key, list) => new
                    {
                        Chain = key,
                        Count = list.Sum(m => m.Count),
                        Ticks = list.Sum(m => m.Elapsed.Ticks),
                    },
                    comparer: _chainEqualityComparer);

            foreach (var metrics in aggregatedMetrics)
            {
                object[] propertyValues = new object[]
                {
                    _formatChain(metrics.Chain),
                    metrics.Count,
                    TimeSpan.FromTicks(metrics.Ticks).TotalMilliseconds
                };

                yield return (_messageTemplate, propertyValues);
            }
        }
    }
}
