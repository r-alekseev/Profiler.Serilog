using System;
using Serilog;
using Serilog.Events;

namespace Profiler
{
    public class SerilogTraceWriterSettings : ISerilogTraceWriterSettings
    {
        public ILogger Logger { get; set; }

        public LogEventLevel LogEventLevel { get; set; } = LogEventLevel.Verbose;

        public Func<string[], string> BuildMessageTemplate { get; set; }
    }
}
