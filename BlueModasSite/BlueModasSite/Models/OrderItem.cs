using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModasSite.Models
{
    public class OrderItem
    {
        public int id;
        public Product product;
        public int quantity;

        public decimal Total
        {
            get
            {
                decimal value = 0;
                value = product.Value * quantity;

                return value;
            }
        }
    }
}
