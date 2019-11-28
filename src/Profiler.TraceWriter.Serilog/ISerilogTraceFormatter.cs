using System;

namespace Profiler
{
    public interface ISerilogTraceFormatter
    {
        (string messageTemplate, object[] propertyValues) Format(TimeSpan elapsed, Chain chain, params object[] args);
    }
}
