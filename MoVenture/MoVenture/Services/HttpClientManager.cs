
using MoVenture.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
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
        

        public static async Task<UserWithToken> Login(string username, string password)
        {
            return await ExecutePostFormUrlEncodedAsync<UserWithToken>("http://", username, password);
        }

        public static async Task<TOutput> ExecutePostFormUrlEncodedAsync<TOutput>(string url, string username, string password)
                where TOutput : class, new()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        var body = $"grant_type=password&username={username}&password={password}";

                        var response = await client.PostAsync(url, new StringContent(body, Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);
                        if (response != null && response.IsSuccessStatusCode)
                        {
                            var stringfiedContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                            var deserializedData = string.IsNullOrWhiteSpace(stringfiedContent)
                            ? null : JsonConvert.DeserializeObject<TOutput>(stringfiedContent);

                            return deserializedData;
                        }
                    }
                    catch (WebException ex)
                    {
                        ex.ToString();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return null;
        }
    }
}
