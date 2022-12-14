using System;
using System.Dynamic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Cinema.Common.Helpers
{
    public class HttpHelper
    {
        public HttpHelper() {}
        
        public async Task<string> SendPostRequest<T>(string url, T model = null, Action<HttpRequestHeaders> headersHandler = null) where T : class
        {
            using (var client = new HttpClient())
            {
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    headersHandler?.Invoke(requestMessage.Headers);

                    if (model != null)
                    {
                        var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                        requestMessage.Content = stringContent;
                    }

                    using (requestMessage.Content)
                    {
                        using (var response = await client.SendAsync(requestMessage))
                        {
                            using (var content = response.Content)
                            {
                                var responseBody = await content.ReadAsStringAsync();
                                if (!response.IsSuccessStatusCode)
                                {
                                    throw new HttpRequestException($"Error with a post request to {url}. StatusCode: {response.StatusCode}. ReasonPhrase: {response.ReasonPhrase}. ResponseBody: {responseBody}");
                                }
                                return responseBody;
                            }
                        }
                    }
                }
            }
        }

        public async Task<string> SendGetRequest(string url, Action<HttpRequestHeaders> headersHandler = null)
        {
            using (var client = new HttpClient())
            {
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    headersHandler?.Invoke(requestMessage.Headers);

                    using (var response = await client.SendAsync(requestMessage))
                    {
                        using (var content = response.Content)
                        {
                            var responseBody = await content.ReadAsStringAsync();
                            if (!response.IsSuccessStatusCode)
                            {
                                throw new HttpRequestException($"Error with a post request to {url}. StatusCode: {response.StatusCode}. ReasonPhrase: {response.ReasonPhrase}. ResponseBody: {responseBody}");
                            }
                            return responseBody;
                        }
                    }
                }
            }
        }

    }
}