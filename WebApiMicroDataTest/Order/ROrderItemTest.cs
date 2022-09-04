using Repository.Orders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApiMicroDataTest.OrderItem
{
    public class ROrderItemTest : IROrderItem
    {

        public async Task Delete(int OrderItemId)
        {
            await Task.Run(() => "Excluído com sucesso");
        }

        public async Task<List<Model.Orders.OrderItem>> GetListAll(Expression<Func<Model.Orders.OrderItem, bool>> predicate, Expression<Func<Model.Orders.OrderItem, object>> includes = null)
        {
            return await Task.Run(() => new List<Model.Orders.OrderItem>()
            {
                new Model.Orders.OrderItem()
                {
                    OrderItemId = 1,
                    ProductCod = 123,
                    Amount = 4,
                    ValueUnit = 20m,
                    OrderId = 1
                }
            });
        }

        public async Task Add(Model.Orders.OrderItem OrderItem)
        {
            await Task.Run(() => "Adicionado com sucesso");
        }

        public async Task Update(Model.Orders.OrderItem OrderItem)
        {
            await Task.Run(() => "Alterado com sucesso");
        }
    }
}
