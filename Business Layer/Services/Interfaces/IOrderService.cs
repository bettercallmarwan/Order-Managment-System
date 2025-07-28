using Business_Layer.Dtos;

namespace Business_Layer.Services.Interfaces
{

        public interface IOrderService
        {
            Task<OrderDetailsDto> CreateOrderAsync(CreateOrderDto dto);
            Task<OrderDetailsDto?> GetOrderAsync(int id);
            Task<IEnumerable<OrderDetailsDto>> GetAllOrdersAsync();
            Task<bool> UpdateOrderStatusAsync(int id, string newStatus);
        }
    }
