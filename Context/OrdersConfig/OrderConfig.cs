using Microsoft.EntityFrameworkCore;
using Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Context.OrdersConfig
{

    public static class OrderConfig
    {
        public static ModelBuilder OrderConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(c => c.OrderId)
                .HasName("PrimaryKey_OrderId");

            modelBuilder.Entity<Order>()
                .Property(c => c.ClientDocument)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(c => c.InsertDate)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(c => c.TotalValue)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            return modelBuilder;
        }
    }
}
