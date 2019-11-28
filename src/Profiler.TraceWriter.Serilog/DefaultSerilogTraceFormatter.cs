using System;

namespace Profiler
{
    internal class DefaultSerilogTraceFormatter : ISerilogTraceFormatter
    {
        private readonly Func<string[], string> _buildMessageTemplate = chain =>
            $"{{elapsed}} ms: {string.Join(", ", chain)}";

        public (string messageTemplate, object[] propertyValues) Format(TimeSpan elapsed, string[] chain, params object[] args)
        {
            string messageTemplate = _buildMessageTemplate(chain);

            object[] propertyValues = new object[args.Length + 1];
            propertyValues[0] = elapsed.TotalMilliseconds;
            args.CopyTo(propertyValues, 1);

            return (messageTemplate, propertyValues);
        }
    }
}
