using Context;
using Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Orders
{
    public class ROrderItem : Repository<OrderItem>
    {
        public ROrderItem(SolutionContext context) : base(context)
        {

        }
    }
}
