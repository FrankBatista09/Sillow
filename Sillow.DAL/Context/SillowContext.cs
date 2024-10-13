using Microsoft.EntityFrameworkCore;
using Sillow.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sillow.DAL.Context
{
    public class SillowContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CustomerFavProperty> CustomerFavProperties { get; set; }
        public DbSet<CustomerSoldProperty> CustomerSoldProperties { get; set; }

        public SillowContext(DbContextOptions<SillowContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerFavProperty>()
                .HasKey(cp => new { cp.CustomerID, cp.PropertyID });

            modelBuilder.Entity<CustomerFavProperty>()
                .HasOne(cp => cp.Customer)
                .WithMany(c => c.FavProperties)
                .HasForeignKey(cp => cp.CustomerID);

            modelBuilder.Entity<CustomerFavProperty>()
                .HasOne(cp => cp.Property)
                .WithMany(c =>  c.FavProperties)
                .HasForeignKey(cp => cp.PropertyID);

            modelBuilder.Entity<CustomerSoldProperty>()
                .HasKey(cp => new { cp.CustomerID, cp.PropertyID });

            modelBuilder.Entity<CustomerSoldProperty>()
                .HasOne(cp => cp.Customer)
                .WithMany(c => c.SoldProperties)
                .HasForeignKey(cp => cp.CustomerID);

            modelBuilder.Entity<CustomerSoldProperty>()
                .HasOne(cd => cd.Property)
                .WithMany(c => c.SoldProperties)
                .HasForeignKey(cp => cp.PropertyID);

            modelBuilder.Entity<Property>()
                .HasOne(a => a.Agent)
                .WithMany(p => p.Properties)
                .HasForeignKey(a => a.AgentID);


        }
    }
}
