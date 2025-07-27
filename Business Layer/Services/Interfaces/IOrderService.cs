using Business_Layer.Dtos;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
