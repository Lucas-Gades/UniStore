using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniStore.Models;

namespace UniStore.Data
{
    public class UniStoreContext : DbContext
    {
        public UniStoreContext (DbContextOptions<UniStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = default!;

        public DbSet<Department>? Department { get; set; }

        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
