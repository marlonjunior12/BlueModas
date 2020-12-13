using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlueModasSite.Service.HttpClientUtils
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientWrapper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = _httpClientFactory.CreateClient();
            return httpClient;
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var httpClient = GetHttpClient();

            return await httpClient.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent requestContent)
        {
            var httpClient = GetHttpClient();

            return await httpClient.PostAsync(url, requestContent);
        }
    }
}
