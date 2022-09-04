using Business.Orders.Interfaces;
using Context;
using Model.Orders;
using Model.Orders.Commands;
using Repository;
using Repository.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Orders
{
    public class BOrder : BRepository<Order>, IBOrder
    {
        ROrder _rOrder;

        public BOrder(SolutionContext context)
            : base(new ROrder(context))
        {
            _rOrder = new ROrder(context);
        }

        public async Task Delete(int orderId)
        {
            try
            {
                await _rOrder.Delete(orderId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Order>> GetAll()
        {
            try
            {
                return await _rOrder.GetListAll(o => true, o => o.OrderItems);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Order> Insert(OrderCommand order)
        {
            try
            {
                await _rOrder.Add(order);

                return order;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Order> UpdateOrder(OrderCommand order)
        {
            try
            {
                await _rOrder.Update(order);

                return order;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
