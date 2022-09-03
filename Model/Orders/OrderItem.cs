using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Orders
{
    public class OrderItem : BaseModel
    {
        public int OrderItemId { get; set; }
        public int ProductCod { get; set; }
        public int Amount { get; set; }
        public decimal ValueUnit { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
