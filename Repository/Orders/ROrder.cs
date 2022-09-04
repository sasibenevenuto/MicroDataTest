using Context;
using Model.Orders;
using Model.Orders.Commands;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Orders
{
    public class ROrder : Repository<Order>
    {
        public ROrder(SolutionContext context) : base(context)
        {

        }

        public async Task Delete(int orderId)
        {
            await base.Delete(o => o.OrderId == orderId);
        }

        public new async Task<List<Order>> GetListAll(Expression<Func<Order, bool>> predicate, Expression<Func<Order, object>> includes = null)
        {
            return await base.GetListAll(predicate, includes);
        }

        public new async Task Add(Order order)
        {
            await base.Add(order);
        }

        public new async Task Update(Order order)
        {
            await base.Update(order);
        }
    }
}
