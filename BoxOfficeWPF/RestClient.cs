using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfficeWPF
{
    public static class RestClient
    {
        public static async Task<string> GetRequest(string url)
        {
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url))
            using (var content = response.Content)
            {
                return await content.ReadAsStringAsync();
            }
        }

        public static async Task<string> PostRequest(string url, string json)
        {
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            using (var response = await client.PostAsync(url, data))
            using (var content = response.Content)
            {
                return await content.ReadAsStringAsync();
            }
        }
    }
}