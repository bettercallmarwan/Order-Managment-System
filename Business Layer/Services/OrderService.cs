using AutoMapper;
using Business_Layer.Dtos;
using Business_Layer.Services.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.UnitOfWork;

namespace Business_Layer.Services
{
    public class OrderService(IUnitOfWork _unitOfWork, IMapper _mapper) : IOrderService
    {
        public async Task<OrderDetailsDto> CreateOrderAsync(CreateOrderDto dto)
        {
            var orderItems = new List<OrderItem>();
            decimal total = 0;

            foreach (var item in dto.Items)
            {
                var product = await _unitOfWork.GetRepository<Product, int>().GetAsync(item.ProductId)
                              ?? throw new Exception("Product not found");

                if (product.Stock < item.Quantity)
                    throw new Exception($"Insufficient stock for product {product.Name}");

                decimal itemTotal = product.Price * item.Quantity;
                orderItems.Add(new OrderItem
                {
                    Quantity = item.Quantity,
                    UnitPrice = product.Price,
                    Discount = 0,
                    OrderId = null
                });

                product.Stock -= item.Quantity;
                total += itemTotal;
            }

            decimal discount = total >= 200 ? 0.1m : total >= 100 ? 0.05m : 0;
            total -= total * discount;

            var order = new Order
            {
                CustomerId = dto.CustomerId,
                PaymentMethod = dto.PaymentMethod,
                Status = "Pending",
                TotalAmount = total,
                OrderItems = orderItems
            };

            await _unitOfWork.GetRepository<Order, int>().AddAsync(order);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<OrderDetailsDto>(order);
        }

        public async Task<OrderDetailsDto?> GetOrderAsync(int id)
        {
            var order = await _unitOfWork.GetRepository<Order, int>().GetAsync(id);
            return order == null ? null : _mapper.Map<OrderDetailsDto>(order);
        }

        public async Task<IEnumerable<OrderDetailsDto>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.GetRepository<Order, int>().GetAllAsync();
            return orders.Select(_mapper.Map<OrderDetailsDto>);
        }

        public async Task<bool> UpdateOrderStatusAsync(int id, string newStatus)
        {
            var orderRepo = _unitOfWork.GetRepository<Order, int>();
            var order = await orderRepo.GetAsync(id);

            if (order == null) return false;

            order.Status = newStatus;
            orderRepo.Update(order);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
