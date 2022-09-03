using Model.Orders;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Orders.Interfaces
{
    public interface IBOrderItem : IRepository<OrderItem>
    {
        Task<List<OrderItem>> GetAll();
        Task<OrderItem> Insert(OrderItem order);
        Task<OrderItem> UpdateOrderItem(OrderItem order);
        Task Delete(int orderItemId);
    }
}
