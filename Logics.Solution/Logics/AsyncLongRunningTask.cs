namespace Logics
{
    public class AsyncLongRunningTask
    {
        static async Task Main(string[] args)
        {
            var id = System.Threading.Thread.CurrentThread.ManagedThreadId;
            var task = LongRunningTaskAsync();
            await task;
        }

        static async Task LongRunningTaskAsync()
        {
            var id = System.Threading.Thread.CurrentThread.ManagedThreadId;
            await Task.Delay(5000);
        }
    }
}
