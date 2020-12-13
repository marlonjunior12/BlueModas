using ApiBlueModas.Models;
using ApiBlueModas.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlueModas.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        /// <summary>
        /// Método para buscar todos os Pedidos
        /// </summary>
        /// <param name="orderService"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Order>>> Get([FromServices] OrderService orderService)
        {
            var orders = await orderService.GetAll();
            return orders;
        }

        /// <summary>
        /// Método para registrar o Pedido
        /// </summary>
        /// <param name="orderService"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Order>> Post([FromServices] OrderService orderService, [FromBody] Order model)
        {
            if (ModelState.IsValid)
            {
                return orderService.Save(model);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
