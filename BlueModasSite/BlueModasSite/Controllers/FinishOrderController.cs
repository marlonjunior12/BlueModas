﻿using BlueModasSite.Models;
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
    public class FinishOrderController : Controller
    {
        private OrderService _orderService;

        public FinishOrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Finish(Client client)
        {
            return RedirectToAction("Index");
        }

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
    }
}
