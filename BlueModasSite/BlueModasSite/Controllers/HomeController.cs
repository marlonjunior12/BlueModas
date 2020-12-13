using BlueModasSite.Models;
using BlueModasSite.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModasSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ProductService _productService;

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            IList<Product> products = _productService.GetProducts().Result;
            return View(products);
            //return View(new List<Product>());
        }


        public IActionResult AddCart(int id)
        {
            Order order = new Order();

            var cart = HttpContext.Session.GetString("cart");
            if(!string.IsNullOrWhiteSpace(cart))
            {
                order = JsonConvert.DeserializeObject<Order>(cart);
            }

            var productOnCart = order.orderItens.Where(x => x.product.Id == id).FirstOrDefault();
            if (productOnCart != null)
            {
                productOnCart.quantity++;
            }
            else
            {
                var product = _productService.GetProduct(id).Result;

                OrderItem orderItem = new OrderItem() { product = product, quantity = 1 };
                order.orderItens.Add(orderItem);
            }

            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(order));

            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
