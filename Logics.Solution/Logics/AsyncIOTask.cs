namespace Logics
{
    public class AsyncIOTask
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var urls = new List<string>
            {
                "https://example.com/page1",
                "https://example.com/page2",
                "https://example.com/page3",
                "https://example.com/page4",
                "https://example.com/page5"
            };

            //var results = await 
        }

        static async Task<IEnumerable<string>> FetchAllDataAsync(HttpClient httpClient, IEnumerable<string> urls)
        {
            var tasks = urls.Select(url => FetchDataAsync(httpClient, url));
            return await Task.WhenAll(tasks);   
        }

        static async Task<string> FetchDataAsync(HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}