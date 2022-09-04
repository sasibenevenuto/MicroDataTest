using Business.Orders.Interfaces;
using Context;
using Model.Orders;
using Model.Orders.Commands;
using Repository.Orders;
using Repository.Orders.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.OrderItems
{   

    public class BOrderItem : IBOrderItem
    {
        IROrderItem _rOrderItem;

        public BOrderItem(IROrderItem rOrderItem)
        {
            _rOrderItem = rOrderItem;
        }       

        public async Task Delete(int orderItemId)
        {
            try
            {
                await _rOrderItem.Delete(orderItemId);
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

        public async Task<OrderItem> Insert(OrderItemCommand orderItem)
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

        public async Task<OrderItem> UpdateOrderItem(OrderItemCommand orderItem)
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
