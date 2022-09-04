using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Orders
{
    public class Order : BaseModel
    {
        public int OrderId { get; set; }
        public string ClientDocument { get; set; }
        public DateTime InsertDate { get; set; }
        public decimal TotalValue { get { return OrderItems?.Sum(i => i.Amount * i.ValueUnit) ?? 0; } set {; } }

        public virtual List<OrderItem> OrderItems { get; set; }


    }
}
