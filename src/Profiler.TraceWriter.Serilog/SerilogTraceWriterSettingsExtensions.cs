using Serilog;
using Serilog.Events;
using System;

namespace Profiler.TraceWriter.Serilog
{
    public static class SerilogTraceWriterSettingsExtensions
    {
        public static ISerilogTraceWriterSettings UseLogger(
            this ISerilogTraceWriterSettings settings, 
            ILogger logger)
        {
            settings.Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            return settings;
        }

        public static ISerilogTraceWriterSettings UseDefaultTraceFormatter(
            this ISerilogTraceWriterSettings settings)
        {
            return settings.UseTraceFormatter(new DefaultSerilogTraceFormatter());
        }

        public static ISerilogTraceWriterSettings UseTraceFormatter(
            this ISerilogTraceWriterSettings settings,
            ISerilogTraceFormatter formatter)
        {
            settings.Formatter = formatter;
            return settings;
        }

        public static ISerilogTraceWriterSettings UseLogEventLevel(
            this ISerilogTraceWriterSettings settings,
            LogEventLevel logEventLevel)
        {
            settings.LogEventLevel = logEventLevel;
            return settings;
        }
    }
}
