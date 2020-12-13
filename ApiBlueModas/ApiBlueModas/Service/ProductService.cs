using ApiBlueModas.Models;
using ApiBlueModas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlueModas.Service
{
    public class ProductService
    {
        private ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _repository.GetAll();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            var products = await _repository.GetById(id);
            return products;
        }
    }
}
