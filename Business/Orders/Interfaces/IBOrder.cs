using Model.Orders;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Orders.Interfaces
{
    public interface IBOrder : IRepository<Order>
    {
        Task<List<Order>> GetAll();
        Task<Order> Insert(Order order);
        Task<Order> UpdateOrder(Order order);
        Task Delete(int orderId);
    }
}
