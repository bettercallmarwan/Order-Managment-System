using Business_Layer.Dtos;
using Business_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Order_Management_System.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController(IOrderService _orderService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            var result = await _orderService.CreateOrderAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id)
        {
            var result = await _orderService.GetOrderAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllOrders()
        {
            var results = await _orderService.GetAllOrdersAsync();
            return Ok(results);
        }

        [HttpPut("{id}/status")]
        public async Task<ActionResult> UpdateOrderStatus(int id, [FromBody] UpdateOrderStatusDto dto)
        {
            var success = await _orderService.UpdateOrderStatusAsync(id, dto.Status);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
