using Business.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model.Orders.Commands;
using System;
using System.Threading.Tasks;

namespace WebApiMicroData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IBOrderItem _bOrderItem;
        public OrderItemController(IBOrderItem bOrderItem)
        {
            _bOrderItem = bOrderItem;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _bOrderItem.GetAll());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderItemCommand command)
        {
            try
            {
               return Ok(await _bOrderItem.Insert(command));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(OrderItemCommand command)
        {
            try
            {
                return Ok(await _bOrderItem.UpdateOrderItem(command));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int ordermItemId)
        {
            try
            {
                await _bOrderItem.Delete(ordermItemId);
                return Ok("Excluído com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
