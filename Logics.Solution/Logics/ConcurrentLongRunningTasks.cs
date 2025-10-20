using System.Diagnostics;

namespace Logics
{
    public class ConcurrentLongRunningTasks
    {
        static async Task Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Task task1 = LongRunningOperation("Task 1");
            Task task2 = LongRunningOperation("Task 2");
            Task task3 = LongRunningOperation("Task 3");
            Task task4 = LongRunningOperation("Task 4");

            await Task.WhenAll(task1, task2, task3, task4);
            stopwatch.Stop();

            Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
        }

        static async Task LongRunningOperation(string taskName)
        {
            Console.WriteLine($"{taskName} started...");
            await Task.Delay(5000);
            Console.WriteLine($"{taskName} completed...");
        }
    }
}
