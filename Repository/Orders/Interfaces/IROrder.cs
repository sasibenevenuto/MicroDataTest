using Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Orders.Interfaces
{
    public interface IROrder : IRepository<Order>
    {
        Task Delete(int orderId);
        Task<List<Order>> GetListAll(Expression<Func<Order, bool>> predicate, Expression<Func<Order, object>> includes = null);
        Task Add(Order order);
        Task Update(Order order);
    }
}
