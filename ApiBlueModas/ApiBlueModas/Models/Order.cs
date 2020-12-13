using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlueModas.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public List<OrderItem> OrderItens { get; set; }
        public Client Client { get; set; }

        public Order()
        {
            OrderItens = new List<OrderItem>();
        }
    }
}
