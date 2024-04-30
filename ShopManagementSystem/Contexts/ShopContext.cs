using Microsoft.EntityFrameworkCore;
using ShopManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementSystem.Contexts
{
    public class ShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=HardwareShopDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<VwBillCustomer> VwBillCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<VwBillCustomer>().ToView("VW_Bill_Customer").HasNoKey();
        }
    }
}
