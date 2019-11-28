using System.Collections.Generic;

namespace Profiler
{
    public interface ISerilogReportFormatter
    {
        IEnumerable<(string messageTemplate, object[] propertyValues)> Format(IEnumerable<ISectionMetrics> metricsCollection);
    }
}
