using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using System.IO;

namespace Profiler.TraceWriter.Serilog.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(new CompactJsonFormatter(), "log.txt")
                .WriteTo.Console()
                .CreateLogger();

            var profiler = new ProfilerConfiguration()
                .UseSerilogTraceWriter(settings => settings
                    .UseLogEventLevel(LogEventLevel.Verbose)
                    .UseDefaultTraceFormatter()
                    .UseLogger(logger))
                .CreateProfiler();

            using (var section = profiler.Section("outer {number}", "one"))
            {
                using (var section2 = section.Section("inner {letter}", "z"))
                {
                    using (section2.Section("deep {sign}", "-"))
                    {

                    }
                }
            }
        }
    }
}
