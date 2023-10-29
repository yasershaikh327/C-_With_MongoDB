using API.Mapper.DtoMapper.Model;
using Database_Access.Mapper.UIMapper.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Database_Access.DatabaseManagement
{
    public class CustomerOrdersDB : DbContext
    {
        public CustomerOrdersDB(DbContextOptions<CustomerOrdersDB> options) : base(options)
        {
        }

        public DbSet<CustomerDTo> customerDTos { get; set; }
        public DbSet<OrderDto> orderDtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDTo>().ToTable("Customer");
            modelBuilder.Entity<OrderDto>().ToTable("Order");

            modelBuilder.Entity<OrderDto>()
            .ToTable("Order")
            .HasOne(o => o.Customer)          // Create a navigation property to the Customer
            .WithMany(c => c.Orders)          // A Customer can have multiple Orders
            .HasForeignKey(o => o.Customer_Id); // Set the foreign key as Customer_ID


        }
    }
}
