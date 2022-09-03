using Context.OrdersConfig;
using Microsoft.EntityFrameworkCore;
using Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Context
{
    public class SolutionContext : DbContext, ISolutionContext
    {
        public SolutionContext(DbContextOptions<SolutionContext> options)
          : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder = OrderConfig.OrderConfigModelBuilder(modelBuilder);
            modelBuilder = OrderItemConfig.OrderItemConfigModelBuilder(modelBuilder);            
            base.OnModelCreating(modelBuilder);
        }
    }
}
