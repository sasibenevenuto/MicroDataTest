using Business.Orders.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Orders.Commands;
using System;
using System.Threading.Tasks;

namespace WebApiMicroData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBOrder _bOrder;
        public OrderController(IBOrder bOrder)
        {
            _bOrder = bOrder;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _bOrder.GetAll());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderCommand command)
        {
            try
            {
                return Ok(await _bOrder.Insert(command));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(OrderCommand command)
        {
            try
            {
                return Ok(await _bOrder.UpdateOrder(command));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int orderId)
        {
            try
            {
                await _bOrder.Delete(orderId);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
