using BlueModasSite.Models;
using BlueModasSite.Service.HttpClientUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModasSite.Service
{
    public class ProductService
    {
        private IHttpClientWrapper _httpClient;

        public ProductService(IHttpClientWrapper httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IList<Product>> GetProducts()
        {
            var response = await _httpClient.GetAsync("https://localhost:44395/api/products");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IList<Product>>(result);
        }

        public async Task<Product> GetProduct(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44395/api/products/{id}");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Product>(result);
        }
    }
}
