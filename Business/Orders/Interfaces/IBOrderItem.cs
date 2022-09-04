using Model.Orders;
using Model.Orders.Commands;
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
        Task<OrderItem> Insert(OrderItemCommand order);
        Task<OrderItem> UpdateOrderItem(OrderItemCommand order);
        Task Delete(int orderItemId);
    }
}
