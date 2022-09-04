using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Orders.Commands
{
    public class OrderItemCommand
    {
        public int OrderItemId { get; set; }
        public int ProductCod { get; set; }
        public int Amount { get; set; }
        public decimal ValueUnit { get; set; }
        public int OrderId { get; set; }

        public static implicit operator OrderItem(OrderItemCommand command)
        {
            return new OrderItem()
            {
                OrderItemId = command.OrderItemId,
                ProductCod = command.ProductCod,
                Amount = command.Amount,
                ValueUnit = command.ValueUnit,
                OrderId = command.OrderId
            };
        }
    }
}
