using ApiBlueModas.Data;
using ApiBlueModas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlueModas.Repository
{
    public class OrderRepository
    {
        private BlueModasDataContext _dataContext;
        public OrderRepository(BlueModasDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Save(Order order)
        {
            _dataContext.Orders.Add(order);
            _dataContext.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAll()
        {
            var orders = await _dataContext.Orders
                                            .Include(x => x.Client)
                                            .Include(x => x.OrderItens).ThenInclude(x => x.Product)
                                           .ToListAsync();
            return orders;
        }
    }
}
