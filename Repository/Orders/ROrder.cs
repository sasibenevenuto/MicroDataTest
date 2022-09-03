using Context;
using Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Orders
{
    public class ROrder : Repository<Order>
    {
        public ROrder(SolutionContext context) : base(context)
        {

        }
    }
}
