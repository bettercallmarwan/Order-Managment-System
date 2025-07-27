using Business_Layer.Dtos;
using Business_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Order_Management_System.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController(ICustomerService _customerService) : ControllerBase
    {
        [HttpGet("{customerId}/orders")]
        public async Task<ActionResult> GetOrdersByCustomerId(int customerId)
        {
            var orders = await _customerService.GetCustomerOrdersAsync(customerId);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CreateCustomerDto dto)
        {
            var customer = await _customerService.CreateCustomerAsync(dto);
            return Ok(dto);
        }
    }
}
