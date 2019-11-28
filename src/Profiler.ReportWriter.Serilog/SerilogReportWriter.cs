using Serilog;
using Serilog.Events;
using System;
using System.Collections.Concurrent;

namespace Profiler
{
    public class SerilogReportWriter : IReportWriter
    {
        private readonly ISerilogReportWriterSettings _settings;
        private readonly ConcurrentBag<ISectionMetrics> _metricsBag;

        public SerilogReportWriter(ISerilogReportWriterSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));

            _metricsBag = new ConcurrentBag<ISectionMetrics>();
        }

        public void Add(ISectionMetrics metrics)
        {
            _metricsBag.Add(metrics);
        }

        public void Write()
        {
            ILogger logger = _settings.Logger;
            LogEventLevel logEventLevel = _settings.LogEventLevel;

            var formatter = _settings.Formatter;
            var metricsCollection = _metricsBag.ToArray();

            foreach ((string messageTemplate, object[] propertyValues) in formatter.Format(metricsCollection))
            {
                logger.Write(logEventLevel, messageTemplate, propertyValues);
            }
        }
    }
}
