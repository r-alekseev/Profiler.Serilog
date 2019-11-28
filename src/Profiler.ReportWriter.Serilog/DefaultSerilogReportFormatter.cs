using System;
using System.Collections.Generic;
using System.Linq;

namespace Profiler
{
    internal class DefaultSerilogReportFormatter : ISerilogReportFormatter
    {
        public IEnumerable<(string messageTemplate, object[] propertyValues)> Format(IEnumerable<ISectionMetrics> metricsCollection)
        {
            var aggregatedMetrics = metricsCollection
                .GroupBy(
                    keySelector: m => m.Chain,
                    elementSelector: m => m,
                    resultSelector: (key, list) => new {
                        Chain = key,
                        Count = list.Sum(m => m.Count),
                        ElapsedMilliseconds = list.Sum(m => m.Elapsed.TotalMilliseconds)
                    });

            string messageTemplate = "{chain} {count} {elapsedMs}";

            foreach(var metrics in aggregatedMetrics)
            {
                object[] propertyValues = new object[]
                {  
                    metrics.Chain.ToString(),
                    metrics.Count,
                    metrics.ElapsedMilliseconds
                };

                yield return (messageTemplate, propertyValues);
            }
        }
    }
}
