using ApiBlueModas.Models;
using ApiBlueModas.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlueModas.Service
{
    public class OrderService
    {
        private OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Save(Order order)
        {
            _orderRepository.Save(order);
            return order;
        }

        public async Task<List<Order>> GetAll()
        {
            var orders = await _orderRepository.GetAll();
            return orders;
        }
    }
}
