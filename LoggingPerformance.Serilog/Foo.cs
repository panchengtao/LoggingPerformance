using LoggingPerformance.Serilog.Logging;

namespace LoggingPerformance.Serilog
{
    public static class Foo
    {
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        public static void Bar(int id, int totalCount)
        {
            Logger.Info("Log message {0} / {1}", id + 1, totalCount);
        }
    }
}