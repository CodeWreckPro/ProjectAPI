using ProjectAPI.Interfaces;
using ProjectAPI.Models;
using System.Net.Http;
using System.Text.Json;

namespace ProjectAPI.BusinessLogic
{
    public class FetchJson : IFetchJson
    {
        private static readonly HttpClient client = new HttpClient();
        public FetchJson() { }

        public async Task<ChangeSets> FetchTasksListAsync(int id)
        {
            id = 20230505;
            var URL = String.Format("Your Get Request/{0}/URI Parameters?api-version=6.0-preview.1", id);
            var response = await client.GetAsync(URL);
            string responseString = await response.Content.ReadAsStringAsync();
            ChangeSets resJson = JsonSerializer.Deserialize<ChangeSets>(responseString);

            return resJson;

        }

    }
}
