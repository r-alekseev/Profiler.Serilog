using System;
using System.Collections.Generic;

namespace Profiler
{
    internal class DefaultSerilogReportFormatter : ISerilogReportFormatter
    {
        public IEnumerable<(string messageTemplate, object[] propertyValues)> Format(IEnumerable<ISectionMetrics> metricsCollection)
        {
            throw new NotImplementedException();
        }
    }
}
