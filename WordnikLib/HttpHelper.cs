using System.Net.Http;
using System.Threading.Tasks;

namespace WordnikLib
{
    class HttpHelper
    {
        public static string BaseURL;
        public static async Task<TResult> GetResultAsync<TResult>(string url_)
        {
            var jsn_content = await GetApiContentAsync(url_);
            if (!string.IsNullOrEmpty(jsn_content))
                return Newtonsoft.Json.JsonConvert.DeserializeObject<TResult>(jsn_content);
            else
                return System.Activator.CreateInstance<TResult>();
        }
        static async Task<string> GetApiContentAsync(string url_)
        {
            using (var client = GetHttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url_);

                    if (response.IsSuccessStatusCode)
                        return await response.Content.ReadAsStringAsync();
                    else
                        return string.Empty;
                }
                catch (HttpRequestException) { return string.Empty; }
            }
        }
        static HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new System.Uri(BaseURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}