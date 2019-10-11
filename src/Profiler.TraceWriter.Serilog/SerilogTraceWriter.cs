using Serilog;
using Serilog.Events;
using System;

namespace Profiler
{
    public class SerilogTraceWriter : ITraceWriter
    {
        private readonly ISerilogTraceWriterSettings _settings;

        private readonly Func<string[], string> _defaultBuildMessageTemplate = chain =>
            $"{{elapsed}} ms: {string.Join(", ", chain)}";

        public SerilogTraceWriter(ISerilogTraceWriterSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public void Write(TimeSpan elapsed, string[] chain, params object[] args)
        {
            ILogger logger = _settings.Logger;
            LogEventLevel logEventLevel = _settings.LogEventLevel;
            var getMessageTemplate = _settings.BuildMessageTemplate ?? _defaultBuildMessageTemplate;

            string messageTemplate = getMessageTemplate(chain);

            object[] newArgs = new object[args.Length + 1];
            newArgs[0] = elapsed.TotalMilliseconds;
            args.CopyTo(newArgs, 1);

            logger.Write(logEventLevel, messageTemplate, newArgs);
        }
    }
}
