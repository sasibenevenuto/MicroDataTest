using Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Orders.Interfaces
{
    public interface IROrderItem : IRepository<OrderItem>
    {
        Task Delete(int orderId);
        Task<List<OrderItem>> GetListAll(Expression<Func<OrderItem, bool>> predicate, Expression<Func<OrderItem, object>> includes = null);
        Task Add(OrderItem order);
        Task Update(OrderItem order);
    }
}
