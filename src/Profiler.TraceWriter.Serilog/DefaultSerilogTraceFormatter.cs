using System;

namespace Profiler
{
    internal class DefaultSerilogTraceFormatter : ISerilogTraceFormatter
    {
        private readonly Func<Chain, string> _buildMessageTemplate = chain =>
            $"{{elapsed}} ms: {string.Join(", ", chain.Formats)}";

        public (string messageTemplate, object[] propertyValues) Format(TimeSpan elapsed, Chain chain, params object[] args)
        {
            string messageTemplate = _buildMessageTemplate(chain);

            object[] propertyValues = new object[args.Length + 1];
            propertyValues[0] = elapsed.TotalMilliseconds;
            args.CopyTo(propertyValues, 1);

            return (messageTemplate, propertyValues);
        }
    }
}
