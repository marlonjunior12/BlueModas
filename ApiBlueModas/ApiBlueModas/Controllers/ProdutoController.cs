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

namespace ApiBlueModas.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        /// <summary>
        /// Método para buscar todos os produtos
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] BlueModasDataContext context)
        {
            var produtos = await context.Produtos.ToListAsync();
            return produtos;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Product>> Get(int id, [FromServices] BlueModasDataContext context)
        {
            var produto = context.Produtos.Where(x => x.Id == id).FirstOrDefault();
            return produto;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post([FromServices] BlueModasDataContext context, [FromBody]Product model)
        {
            if(ModelState.IsValid)
            {
                context.Produtos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
