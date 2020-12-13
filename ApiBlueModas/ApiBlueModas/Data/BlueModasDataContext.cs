using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBlueModas.Models;

namespace ApiBlueModas.Data
{
    public class BlueModasDataContext : DbContext
    {
        public BlueModasDataContext(DbContextOptions<BlueModasDataContext> options) : base(options)
        {

        }

        public DbSet<Product> Produtos { get; set; }
    }
}
