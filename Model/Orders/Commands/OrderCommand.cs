using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Orders.Commands
{
    public class OrderCommand
    {
        public int OrderId { get; set; }
        public string ClientDocument { get; set; }
        public DateTime InsertDate { get; set; }

        public static implicit operator Order(OrderCommand command)
        {
            return new Order()
            {
                OrderId = command.OrderId,
                ClientDocument = command.ClientDocument,
                InsertDate = command.InsertDate
            };
        }
    }
}
