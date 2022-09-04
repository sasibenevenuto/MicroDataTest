using Business.OrderItems;
using Business.Orders.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApiMicroDataTest.OrderItem
{

    [TestClass]
    public class BOrderItemTest
    {

        [TestMethod]
        public void TestGetAll()
        {
            IBOrderItem _bOrderItem = new BOrderItem(new ROrderItemTest());

            var okResult = _bOrderItem.GetAll().GetAwaiter().GetResult();

            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        public void TestAdd()
        {
            IBOrderItem _bOrderItem = new BOrderItem(new ROrderItemTest());

            var okResult = _bOrderItem.Insert(new Model.Orders.Commands.OrderItemCommand()
            {
                OrderItemId = 1,
                ProductCod = 123,
                Amount = 4,
                ValueUnit = 20m,
                OrderId = 1
            }).GetAwaiter().GetResult();

            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        public void TestUpdate()
        {
            IBOrderItem _bOrderItem = new BOrderItem(new ROrderItemTest());

            var okResult = _bOrderItem.UpdateOrderItem(new Model.Orders.Commands.OrderItemCommand()
            {
                OrderItemId = 1,
                ProductCod = 123,
                Amount = 4,
                ValueUnit = 20m,
                OrderId = 1
            }).GetAwaiter().GetResult();

            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        public void TestDelete()
        {
            try
            {
                IBOrderItem _bOrderItem = new BOrderItem(new ROrderItemTest());

                _bOrderItem.Delete(1).GetAwaiter().GetResult();
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}
