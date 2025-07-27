using AutoMapper;
using Business_Layer.Dtos;
using Business_Layer.Services.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.UnitOfWork;

namespace Business_Layer.Services
{
    public class CustomerService(IUnitOfWork _unitOfWork, IMapper _mapper) : ICustomerService
    {
        public async Task<Customer> CreateCustomerAsync(CreateCustomerDto createUserDto)
        {
            var customerToCreate = _mapper.Map<Customer>(createUserDto);
            await _unitOfWork.GetRepository<Customer, int>().AddAsync(customerToCreate);

            await _unitOfWork.CompleteAsync();

            return customerToCreate;
        }   

        public async Task<IEnumerable<Order>> GetCustomerOrdersAsync(int id)
        {
            var orderRepo = _unitOfWork.GetRepository<Order, int>();

            var orders = await orderRepo.GetAllAsync(E => E.CustomerId == id);

            return orders;
        }


    }
}
