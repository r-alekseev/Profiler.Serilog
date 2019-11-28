using System;

namespace Profiler
{
    public static class ProfilerConfigurationReportWriterExtensions
    {
        public static IProfilerConfiguration UseSerilogReportWriter(this IProfilerConfiguration settings,
            Action<ISerilogReportWriterSettings> configure)
        {
            var serilogReportWriterSettings = new SerilogReportWriterSettings();
            configure(serilogReportWriterSettings);
            settings.CreateReportWriter = () => new SerilogReportWriter(serilogReportWriterSettings);
            return settings;
        }
    }
}
