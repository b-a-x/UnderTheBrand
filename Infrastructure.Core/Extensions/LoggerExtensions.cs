using System;
using Microsoft.Extensions.Logging;

namespace UnderTheBrand.Infrastructure.Core.Extensions
{
    public static class LoggerExtensions
    {
        private static readonly Action<ILogger, string, Exception> _errorParamsStringException =
            LoggerMessage.Define<string>(LogLevel.Error, new EventId(100, nameof(Error)), "{message}");

        private static readonly Action<ILogger, string, Exception> _informationParamsString = 
            LoggerMessage.Define<string>(LogLevel.Information, new EventId(300, nameof(Information)), "{message}");

        public static void Error(this ILogger logger, string message, Exception exception) => _errorParamsStringException(logger, message, exception);

        public static void Information(this ILogger logger, string message) => _informationParamsString(logger, message, null);
    }
}
