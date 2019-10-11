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

        public static ISerilogTraceWriterSettings UseMessageTemplateBuilder(
            this ISerilogTraceWriterSettings settings, 
            Func<string[], string> buildMessageTemplate)
        {
            settings.BuildMessageTemplate = buildMessageTemplate;
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
