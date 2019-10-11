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
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(new CompactJsonFormatter(), "log.txt")
                .WriteTo.Console()
                .CreateLogger();

            var profiler = new ProfilerConfiguration()
                .UseSerilogTraceWriter(settings => settings
                    .UseLogEventLevel(LogEventLevel.Verbose)
                    .UseLogger(logger))
                .CreateProfiler();

            using (var section = profiler.Section("outer {number}", "one"))
            {
                using (section.Section("inner {letter}", "z"))
                {

                }
            }
        }
    }
}
