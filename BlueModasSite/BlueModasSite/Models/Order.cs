using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModasSite.Models
{
    public class Order
    {
        public int id;
        public List<OrderItem> orderItens;
        public Client client;

        public Order()
        {
            orderItens = new List<OrderItem>();
        }

        public decimal Total
        {
            get
            {
                decimal value = 0;

                foreach (var item in orderItens)
                {
                    value += item.product.Value * item.quantity;
                }

                return value;
            }
        }
    }
}
