using Microsoft.Extensions.Logging;

namespace BudgetBakers.Wallet.Net.Tests.Infrastructure
{
    internal sealed class TestLogger<T> : ILogger<T>
    {
        private readonly LogLevel _minLevel;

        public List<(LogLevel Level, string Message)> Logs { get; } = [];

        public TestLogger(LogLevel minLevel = LogLevel.Trace)
        {
            _minLevel = minLevel;
        }

        public bool IsEnabled(LogLevel logLevel) => logLevel >= _minLevel;

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            if (IsEnabled(logLevel))
                Logs.Add((logLevel, formatter(state, exception)));
        }
    }
}
