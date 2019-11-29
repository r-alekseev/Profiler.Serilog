using System;

namespace Profiler
{
    public static class ProfilerConfigurationTraceWriterExtensions
    {
        public static IProfilerConfiguration UseSerilogTraceWriter(this IProfilerConfiguration settings,
            Action<ISerilogTraceWriterSettings> configure)
        {
            var serilogTraceWriterSettings = new SerilogTraceWriterSettings();
            configure(serilogTraceWriterSettings);
            settings.CreateTraceWriter = () => new SerilogTraceWriter(serilogTraceWriterSettings);
            return settings;
        }
    }
}
