using Serilog;
using Serilog.Events;

namespace Profiler
{
    internal class SerilogReportWriterSettings : ISerilogReportWriterSettings
    {
        public ILogger Logger { get; set; }

        public LogEventLevel LogEventLevel { get; set; } = LogEventLevel.Verbose;

        public ISerilogReportFormatter Formatter { get; set; } = new DefaultSerilogReportFormatter();
    }
}
