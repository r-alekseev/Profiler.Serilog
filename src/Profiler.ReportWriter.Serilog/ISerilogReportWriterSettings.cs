using Serilog;
using Serilog.Events;

namespace Profiler
{
    public interface ISerilogReportWriterSettings
    {
        ILogger Logger { get; set; }

        LogEventLevel LogEventLevel { get; set; }

        ISerilogReportFormatter Formatter { get; set; }
    }
}
