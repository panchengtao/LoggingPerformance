using LoggingPerformance.NLog.Logging;

namespace LoggingPerformance.NLog
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