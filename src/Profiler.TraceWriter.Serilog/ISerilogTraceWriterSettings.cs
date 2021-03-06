﻿using Serilog;
using Serilog.Events;

namespace Profiler
{
    public interface ISerilogTraceWriterSettings
    {
        ILogger Logger { get; set; }

        LogEventLevel LogEventLevel { get; set; }

        ISerilogTraceFormatter Formatter { get; set; }
    }
}
