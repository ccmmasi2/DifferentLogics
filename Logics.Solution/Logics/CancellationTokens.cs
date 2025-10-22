namespace Logics
{
    public class CancellationTokens
    {
        static async Task Main(string[] args)
        {
            using (var cts = new CancellationTokenSource())
            {
                var task = LongRunningOperationAsync(cts.Token);

                Console.WriteLine("Press any key to cancel the operation...");
                Console.ReadKey();

                cts.Cancel();

                try
                {
                    await task;
                }
                catch (OperationCanceledException ex)
                {
                    // Handle cancellation
                    Console.WriteLine("Operation was canceled.");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            static async Task<string> LongRunningOperationAsync(CancellationToken cancellationToken)
            {
                try
                {
                    //Check if cancellation was requested before starting the operation
                    cancellationToken.ThrowIfCancellationRequested();

                    string result = await DoSomeWorkAsync();

                    cancellationToken.ThrowIfCancellationRequested();

                    return result;
                }
                catch (OperationCanceledException ex)
                {
                    // Handle cancellation
                    Console.WriteLine("Operation was canceled.");
                    throw;
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    Console.WriteLine("An error occurred: " + ex.Message);
                    throw;
                }
            }

            static async Task<string> DoSomeWorkAsync()
            {
                await Task.Delay(TimeSpan.FromSeconds(10));
                return "Operation completed successfully";
            }
        }
    }
}
