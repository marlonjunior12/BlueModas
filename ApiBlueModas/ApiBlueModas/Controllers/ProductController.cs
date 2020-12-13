using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBlueModas.Models;
using ApiBlueModas.Data;
using ApiBlueModas.Service;

namespace ApiBlueModas.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// Método para buscar todos os produtos
        /// </summary>
        /// <param name="productService"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] ProductService productService)
        {
            var products = await productService.GetAll();
            return products;
        }

        /// <summary>
        /// Método para buscar produto por ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productService"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> Get(int id, [FromServices] ProductService productService)
        {
            var product = await productService.GetById(id);
            return product;
        }
    }
}
