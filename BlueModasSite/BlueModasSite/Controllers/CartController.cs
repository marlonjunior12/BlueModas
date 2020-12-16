using BlueModasSite.Models;
using BlueModasSite.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModasSite.Controllers 
{
    public class CartController : Controller
    {
        private OrderService _orderService;

        public CartController(OrderService orderService)
        {
            _orderService = orderService;
        }

        //public IActionResult SaveOrder(Order order)
        //{
        //    var cart = HttpContext.Session.GetString("cart");
        //    if (!string.IsNullOrWhiteSpace(cart))
        //    {
        //        order = JsonConvert.DeserializeObject<Order>(cart);
        //    }

        //    _orderService.PostOrder(order);

        //    return RedirectToAction("Index");
        //}

        public IActionResult Index()
        {
            Order order = new Order();

            var cart = HttpContext.Session.GetString("cart");
            if (!string.IsNullOrWhiteSpace(cart))
            {
                order = JsonConvert.DeserializeObject<Order>(cart);
            }

            return View(order);
        }

        public IActionResult AddItem(int id)
        {
            Order order = new Order();

            var cart = HttpContext.Session.GetString("cart");
            if (!string.IsNullOrWhiteSpace(cart))
            {
                order = JsonConvert.DeserializeObject<Order>(cart);
            }

            var productOnCart = order.orderItens.Where(x => x.product.Id == id).FirstOrDefault();
            if (productOnCart != null)
            {
                productOnCart.quantity++;
            }

            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(order));

            return RedirectToAction("Index");
        }

        public IActionResult RemoveItem(int id)
        {
            Order order = new Order();

            var cart = HttpContext.Session.GetString("cart");
            if (!string.IsNullOrWhiteSpace(cart))
            {
                order = JsonConvert.DeserializeObject<Order>(cart);
            }

            var productOnCart = order.orderItens.Where(x => x.product.Id == id).FirstOrDefault();
            if (productOnCart != null)
            {
                productOnCart.quantity--;

                if (productOnCart.quantity == 0)
                {
                    order.orderItens.Remove(productOnCart);
                }               
            }

            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(order));

            return RedirectToAction("Index");
        }
    }
}
