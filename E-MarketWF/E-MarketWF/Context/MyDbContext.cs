using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MarketWF.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyProducts")
        {

        }

        public DbSet<Product> Products { get; set; }

    }
}
