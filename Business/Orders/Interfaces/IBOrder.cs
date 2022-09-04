using Model.Orders;
using Model.Orders.Commands;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Orders.Interfaces
{
    public interface IBOrder
    {
        Task<List<Order>> GetAll();
        Task<Order> Insert(OrderCommand order);
        Task<Order> UpdateOrder(OrderCommand order);
        Task Delete(int orderId);
    }
}
