using Microsoft.EntityFrameworkCore;
using Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Context.OrdersConfig
{

    public static class OrderItemConfig
    {
        public static ModelBuilder OrderItemConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasKey(c => c.OrderItemId)
                .HasName("PrimaryKey_OrderItemId");

            modelBuilder.Entity<OrderItem>()
                .Property(c => c.ProductCod)
                .IsRequired();

            modelBuilder.Entity<OrderItem>()
                .Property(c => c.Amount)
                .IsRequired();

            modelBuilder.Entity<OrderItem>()
                .Property(c => c.ValueUnit)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            modelBuilder.Entity<OrderItem>()
                .Property(c => c.OrderId)
                .IsRequired();

            modelBuilder.Entity<OrderItem>()
                 .HasOne(c => c.Order)
                 .WithMany(c => c.OrderItems);

            return modelBuilder;
        }
    }
}
