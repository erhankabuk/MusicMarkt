using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
     public class MarktContext :DbContext
    {
        public MarktContext(DbContextOptions<MarktContext> options): base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands{ get; set; }
        public DbSet<Product> Products{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
