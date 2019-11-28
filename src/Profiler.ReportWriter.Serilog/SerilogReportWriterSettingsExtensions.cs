using Serilog;
using Serilog.Events;
using System;

namespace Profiler
{
    public static class SerilogReportWriterSettingsExtensions
    {
        public static ISerilogReportWriterSettings UseLogger(
            this ISerilogReportWriterSettings settings, 
            ILogger logger)
        {
            settings.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            return settings;
        }

        public static ISerilogReportWriterSettings UseDefaultReportFormatter(
            this ISerilogReportWriterSettings settings)
        {
            return settings.UseReportFormatter(new DefaultSerilogReportFormatter());
        }

        public static ISerilogReportWriterSettings UseReportFormatter(
            this ISerilogReportWriterSettings settings,
            ISerilogReportFormatter formatter)
        {
            settings.Formatter = formatter;
            return settings;
        }

        public static ISerilogReportWriterSettings UseLogEventLevel(
            this ISerilogReportWriterSettings settings,
            LogEventLevel logEventLevel)
        {
            settings.LogEventLevel = logEventLevel;
            return settings;
        }
    }
}
