using Business.Orders;
using Business.Orders.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiMicroDataTest.Order
{

    [TestClass]
    public class BOrderTest
    {

        [TestMethod]
        public void TestGetAll()
        {
            IBOrder _bOrder = new BOrder(new ROrderTest());

            var okResult = _bOrder.GetAll().GetAwaiter().GetResult();

            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        public void TestAdd()
        {
            IBOrder _bOrder = new BOrder(new ROrderTest());

            var okResult = _bOrder.Insert(new Model.Orders.Commands.OrderCommand()
            {
                OrderId = 1,
                ClientDocument = "123",
                InsertDate = DateTime.Now
            }).GetAwaiter().GetResult();

            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        public void TestUpdate()
        {
            IBOrder _bOrder = new BOrder(new ROrderTest());

            var okResult = _bOrder.UpdateOrder(new Model.Orders.Commands.OrderCommand()
            {
                OrderId = 1,
                ClientDocument = "123",
                InsertDate = DateTime.Now
            }).GetAwaiter().GetResult();

            Assert.IsNotNull(okResult);
        }

        [TestMethod]
        public void TestDelete()
        {
            try
            {
                IBOrder _bOrder = new BOrder(new ROrderTest());

                _bOrder.Delete(1).GetAwaiter().GetResult();
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}
