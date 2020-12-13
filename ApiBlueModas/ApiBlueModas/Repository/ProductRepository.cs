using ApiBlueModas.Data;
using ApiBlueModas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlueModas.Repository
{
    public class ProductRepository
    {
        private BlueModasDataContext _dataContext;
        public ProductRepository(BlueModasDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _dataContext.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var product = _dataContext.Products.Where(x => x.Id == id).FirstOrDefault();
            return product;
        }
    }
}
