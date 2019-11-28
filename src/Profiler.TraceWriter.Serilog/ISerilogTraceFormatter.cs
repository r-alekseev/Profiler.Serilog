using System;

namespace Profiler
{
    public interface ISerilogTraceFormatter
    {
        (string messageTemplate, object[] propertyValues) Format(TimeSpan elapsed, string[] chain, params object[] args);
    }
}
