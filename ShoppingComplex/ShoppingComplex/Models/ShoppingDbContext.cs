using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingComplex.Models
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext() : base("name=DefaultConnection") { }

        public virtual DbSet<Customer> Customers { get; set; }
    }
}