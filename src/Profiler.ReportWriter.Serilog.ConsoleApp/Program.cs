using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Profiler.ReportWriter.Serilog.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(new CompactJsonFormatter(), "report.txt")
                .WriteTo.Console()
                .CreateLogger();

            var profiler = new ProfilerConfiguration()
                .UseSerilogReportWriter(settings => settings
                    .UseLogEventLevel(LogEventLevel.Verbose)
                    .UseDefaultReportFormatter()
                    .UseLogger(logger))
                .CreateProfiler();

            int n = 100;

            var tasks = new Task[n];

            for (int i = 0; i < n; i++)
            {
                tasks[i] = Task.Factory.StartNew(() =>
                {
                    using (var section = profiler.Section("outer {number}", "one"))
                    {
                        using (var section2 = section.Section("inner {letter}", "z"))
                        {
                            using (section2.Section("deep {sign}", "-"))
                            {

                            }

                            using (section2.Section("deep {sign}", "+"))
                            {

                            }
                        }

                        using (var section2 = section.Section("inner {letter}", "x"))
                        {
                            using (section2.Section("deep {sign}", "-"))
                            {

                            }

                            using (section2.Section("deep {sign}", "+"))
                            {

                            }
                        }
                    }
                });
            }

            Task.WaitAll(tasks);

            profiler.WriteReport();
        }
    }
}
