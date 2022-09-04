using Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApiMicroDataTest.Order
{
    public class ROrderTest : IRepository<Model.Orders.Order>
    {

        public async Task Delete(int orderId)
        {
            await Task.Run(() => "Excluído com sucesso");
        }

        public async Task<List<Model.Orders.Order>> GetListAll(Expression<Func<Model.Orders.Order, bool>> predicate, Expression<Func<Model.Orders.Order, object>> includes = null)
        {
            return await Task.Run(() => new List<Model.Orders.Order>()
            {
                new Model.Orders.Order()
                {
                    OrderId = 1,
                    ClientDocument = "123",
                    InsertDate = DateTime.Now,
                    OrderItems = new List<Model.Orders.OrderItem>()
                    {
                        new Model.Orders.OrderItem()
                        {
                            OrderItemId = 1,
                            ProductCod = 123,
                            Amount = 4,
                            ValueUnit = 20m,
                            OrderId = 1
                        }
                    }
                }
            });
        }

        public async Task Add(Model.Orders.Order order)
        {
            await Task.Run(() => "Adicionado com sucesso");
        }

        public async Task Update(Model.Orders.Order order)
        {
            await Task.Run(() => "Alterado com sucesso");
        }
    }
}
