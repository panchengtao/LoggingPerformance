using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LoggingPerformance.NLog.Logging;
using LoggingPerformance.NLog.Logging.LogProviders;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;
using LogLevel = NLog.LogLevel;

namespace LoggingPerformance.NLog
{
    internal class Program
    {
        private static int _countPerThread = 5000000;
        private static int _producersCount = 1;
        private static int _totalCount;

        private static void Main(string[] args)
        {
            var config = new LoggingConfiguration();
            
            var fileTarget = new FileTarget
            {
                Name = "FileTarget",
                FileName = "Log.txt",
                KeepFileOpen = true,
                ConcurrentWrites = false,
                AutoFlush = false
            };

            var asyncFileTarget = new AsyncTargetWrapper(fileTarget)
            {
                TimeToSleepBetweenBatches = 0,
                OverflowAction = AsyncTargetWrapperOverflowAction.Block,
                BatchSize = 500
            };

            config.AddTarget("file", asyncFileTarget);
            config.AddRuleForAllLevels(asyncFileTarget);
            LogManager.Configuration = config;
            LogManager.ReconfigExistingLoggers();
            LogProvider.SetCurrentLogProvider(new NLogLogProvider());

            //var config = new LoggingConfiguration();
            //var consoleTarget = new ColoredConsoleTarget();
            //config.AddTarget("console", consoleTarget);
            //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, consoleTarget));
            //LogManager.Configuration = config;

            //var config = new LoggingConfiguration();
            //var fileTarget = new FileTarget { FileName = "Log.Txt" };
            //config.AddTarget("file", fileTarget);
            //config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, fileTarget));
            //LogManager.Configuration = config;

            if (args.Length >= 1 && !int.TryParse(args[0], out _countPerThread) || _countPerThread < 1)
            {
                Console.WriteLine("Usage: LoggingPerformance.exe [CountPerThread] [ProducersCount] [ConsumersCount]");
                throw new ArgumentException(
                    "Invalid first argument! Provide items count per thread as a first application argument.");
            }

            if (args.Length >= 2 && !int.TryParse(args[1], out _producersCount) || _producersCount < 1)
            {
                Console.WriteLine("Usage: LoggingPerformance.exe [CountPerThread] [ProducersCount] [ConsumersCount]");
                throw new ArgumentException(
                    "Invalid second argument! Provide producers count as a second application argument.");
            }

            Console.WriteLine("NLog");
            Console.WriteLine("Stopwatch.IsHighResolution = {0}", Stopwatch.IsHighResolution);

            _countPerThread = _countPerThread / _producersCount;
            _totalCount = _countPerThread * _producersCount;

            try
            {
                var results = new double[_totalCount];
                for (var i = 0; i < _totalCount; i++)
                    results[i] = 0;

                // Start the stopwatch timer.
                var stopWatch = Stopwatch.StartNew();

                // Create and start producer tasks.
                var producers = new Task[_producersCount];
                for (var producerIndex = 0; producerIndex < _producersCount; producerIndex++)
                    producers[producerIndex] = Task.Factory.StartNew(state =>
                    {
                        var index = (int)state;
                        for (var i = 0; i < _countPerThread; i++)
                        {
                            var id = index * _countPerThread + i;
                            results[id] = stopWatch.ElapsedTicks;

                            Foo.Bar(id, _totalCount);

                            results[id] = stopWatch.ElapsedTicks - results[id];
                        }
                    }, producerIndex, TaskCreationOptions.LongRunning);

                // Wait for producing complete.
                Task.WaitAll(producers);
                stopWatch.Stop();

                Console.WriteLine();

                // Adjust result table.
                var frequency = Stopwatch.Frequency / (1000.0 * 1000.0);
                for (var i = 0; i < _totalCount; i++)
                    results[i] /= frequency;
                Array.Sort(results);

                // Show report message.
                var throughput = _totalCount / ((double)stopWatch.ElapsedTicks / Stopwatch.Frequency);
                Console.WriteLine("Generated {0} values in {1}ms (throughput = {2:F3} ops per second)", _totalCount,
                    stopWatch.ElapsedMilliseconds, throughput);

                // Show latency histogram.
                ShowHistogram(results, 10);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Wait for user stop action.
                Console.WriteLine("Press any key to stop...");
                Console.ReadKey();
            }
        }

        #region Utility methods

        private static void ShowHistogram(IList<double> values, int count, double? maxValue = null)
        {
            // Calculate mean value.
            var mean = values.Aggregate((s, v) => s + v) / values.Count;
            Console.WriteLine("Mean latency = {0:F3}mcs", mean);

            // Calculate bounds values.
            var bound99 = (int)(values.Count * 99.0 / 100.0);
            Console.WriteLine("99% observations less than = {0:F3}mcs", values[bound99]);
            var bound9999 = (int)(values.Count * 99.99 / 100.0);
            Console.WriteLine("99.99% observations less than = {0:F3}mcs", values[bound9999]);

            var min = values[0];
            var max = maxValue ?? values[bound99];
            var step = (max - min) / count;

            for (var i = 0; i < count; i++)
            {
                var lower = min + i * step;
                var upper = min + (i + 1) * step;
                Console.WriteLine("{0}) {1:F3} - {2:F4} = {3}", i, lower, upper,
                    values.Count(v => v >= lower && v <= upper));
            }
        }

        #endregion
    }
}