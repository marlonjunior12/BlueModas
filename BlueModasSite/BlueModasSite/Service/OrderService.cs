using BlueModasSite.Models;
using BlueModasSite.Service.HttpClientUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlueModasSite.Service
{
    public class OrderService
    {
        private IHttpClientWrapper _httpClient;

        public OrderService(IHttpClientWrapper httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Order> PostOrder(Order order)
        {
            var content = new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"https://localhost:44395/api/orders", content);
            var result = await response.Content.ReadAsStringAsync();

            return order;
        }
    }
}
