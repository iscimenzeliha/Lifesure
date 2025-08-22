using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Proje7MVC.Services
{
    public class LinkedinService
    {
        private readonly string apiKey = ConfigurationManager.AppSettings["X-RapidAPI-Key"];
        private readonly string apiHost = ConfigurationManager.AppSettings["X-RapidAPI-Host"];

        public async Task<int> GetFollowerCountAsync(string username)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", apiHost);

                var response = await client.GetAsync($"https://{apiHost}/api/v1/company/profile?company={username}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(jsonString);

                    return json["data"]?["follower_count"]?.Value<int>() ?? 0;
                }

                return 0;
            }
        }
    }
}
