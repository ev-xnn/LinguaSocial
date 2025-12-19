using System.Collections.Generic;
using System.Data.Entity;

namespace YourProject.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}

