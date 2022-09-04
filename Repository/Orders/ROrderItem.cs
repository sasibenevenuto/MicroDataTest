using Context;
using Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Orders
{
    public class ROrderItem : Repository<OrderItem>
    {
        public ROrderItem(SolutionContext context) : base(context)
        {

        }

        public async Task Delete(int orderItemId)
        {
            await base.Delete(o => o.OrderItemId == orderItemId);
        }

        public new async Task<List<OrderItem>> GetListAll(Expression<Func<OrderItem, bool>> predicate, Expression<Func<OrderItem, object>> includes = null)
        {
            return await base.GetListAll(predicate, includes);
        }

        public new async Task Add(OrderItem order)
        {
            await base.Add(order);
        }

        public new async Task Update(OrderItem order)
        {
            await base.Update(order);
        }
    }
}
