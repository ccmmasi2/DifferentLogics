namespace Logics
{
    public class ParallelLoops
    {
        private static void Main (string[] args)
        {
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine($"Iteration {i} is being processed by Thread {Thread.CurrentThread.ManagedThreadId}");
            });

            var collection = new List<int> { 1, 2, 3, 4, 5 };

            Parallel.ForEach(collection, item =>
            {
                Console.WriteLine($"Processing item {item} on Thread {Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}
