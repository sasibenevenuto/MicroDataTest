using Business.Orders.Interfaces;
using Context;
using Model.Orders;
using Repository.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.OrderItems
{   

    public class BOrderItem : BRepository<OrderItem>, IBOrderItem
    {
        ROrderItem _rOrderItem;

        public BOrderItem(SolutionContext context)
            : base(new ROrderItem(context))
        {
            _rOrderItem = new ROrderItem(context);
        }

        public async Task Delete(int orderItemId)
        {
            try
            {
                await _rOrderItem.Delete(o => o.OrderItemId == orderItemId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<OrderItem>> GetAll()
        {
            try
            {
                return await _rOrderItem.GetListAll(o => true);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<OrderItem> Insert(OrderItem orderItem)
        {
            try
            {
                await _rOrderItem.Add(orderItem);

                return orderItem;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<OrderItem> UpdateOrderItem(OrderItem orderItem)
        {
            try
            {
                await _rOrderItem.Update(orderItem);

                return orderItem;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
