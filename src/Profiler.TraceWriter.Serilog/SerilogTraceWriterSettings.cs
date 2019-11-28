using Serilog;
using Serilog.Events;

namespace Profiler
{
    internal class SerilogTraceWriterSettings : ISerilogTraceWriterSettings
    {
        public ILogger Logger { get; set; }

        public LogEventLevel LogEventLevel { get; set; } = LogEventLevel.Verbose;

        public ISerilogTraceFormatter Formatter { get; set; } = new DefaultSerilogTraceFormatter();
    }
}
