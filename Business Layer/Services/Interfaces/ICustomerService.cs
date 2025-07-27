using Business_Layer.Dtos;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<Customer> CreateCustomerAsync(CreateCustomerDto createUserDto);
        public Task<IEnumerable<Order>> GetCustomerOrdersAsync(int id);
    }
}
