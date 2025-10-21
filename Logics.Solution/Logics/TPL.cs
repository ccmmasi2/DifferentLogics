namespace Logics
{
    public class TPL
    {
        private static async Task Main(string[] args)
        {
            Task task = Task.Run(() =>
            {
                Console.WriteLine("This code will run asynchronously");
            });
            await task;

            Task[] tasks = new Task[10];

            for(int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    Console.WriteLine("This code will run asynchronously");
                });
            }

            Task.WhenAll(tasks).Wait();
        }
    }
}
