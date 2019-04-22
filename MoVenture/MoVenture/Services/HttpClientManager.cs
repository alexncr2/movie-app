
using MoVenture.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoVenture.Services
{
    public static class HttpClientManager
    {
        public static async Task<List<Movie>> GetMovieData()
        {
            return await GetGenericData<List<Movie>>("");
        }

        // private get generic
        private static async Task<T> GetGenericData<T>(string url) where T : class, new()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response == null || !response.IsSuccessStatusCode)
            {
                return new T();
            }
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(content);

            return data;
        }

        // private post generic
        private static async Task<T> PostGenericData<T,U>(string url, U u) where T : class, new() where U : class, new()
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(u)));
            
            if (response == null || !response.IsSuccessStatusCode)
            {
                return new T();
            }

            var content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(content);

            return data;
        }
    }
}
