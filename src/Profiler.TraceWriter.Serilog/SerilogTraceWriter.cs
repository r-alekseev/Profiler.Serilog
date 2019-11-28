using Serilog;
using Serilog.Events;
using System;

namespace Profiler
{
    public class SerilogTraceWriter : ITraceWriter
    {
        private readonly ISerilogTraceWriterSettings _settings;

        public SerilogTraceWriter(ISerilogTraceWriterSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public void Write(TimeSpan elapsed, string[] chain, params object[] args)
        {
            ILogger logger = _settings.Logger;
            LogEventLevel logEventLevel = _settings.LogEventLevel;

            var formatter = _settings.Formatter;

            (string messageTemplate, object[] propertyValues) = formatter.Format(elapsed, chain, args);

            logger.Write(logEventLevel, messageTemplate, propertyValues);
        }
    }
}
