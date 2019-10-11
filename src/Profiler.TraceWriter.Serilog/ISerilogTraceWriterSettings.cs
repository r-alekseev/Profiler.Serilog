﻿using Serilog;
using Serilog.Events;
using System;

namespace Profiler
{
    public interface ISerilogTraceWriterSettings
    {
        ILogger Logger { get; set; }

        LogEventLevel LogEventLevel { get; set; }

        Func<string[], string> BuildMessageTemplate { get; set; }
    }
}