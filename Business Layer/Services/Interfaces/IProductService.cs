using Business_Layer.Dtos;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProductsAsync();
        public Task<ProductDto?> GetProductAsync(int id);
        public Task<Product?> AddProductAsync(ProductDto dto);
        public Task<ProductDto?> UpdateProductAsync(int id, ProductDto dto);
            }
}
