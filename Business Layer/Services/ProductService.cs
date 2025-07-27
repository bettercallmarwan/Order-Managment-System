using AutoMapper;
using Business_Layer.Dtos;
using Business_Layer.Services.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.UnitOfWork;

namespace Business_Layer.Services
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<Product?> AddProductAsync(ProductDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Name))
            {
                var product = _mapper.Map<Product>(dto);
                await _unitOfWork.GetRepository<Product, int>().AddAsync(product);
                await _unitOfWork.CompleteAsync();
                return product;
            }
            return null;
        }

        public async Task<ProductDto?> GetProductAsync(int id)
        {
            var product = await _unitOfWork.GetRepository<Product, int>().GetAsync(id);
            if (product is null)
                return null;
            var productToReturn = _mapper.Map<ProductDto>(product);
            return productToReturn;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync();
            return products;
        }

        public async Task<ProductDto?> UpdateProductAsync(int id, ProductDto dto)
        {
            var product = await _unitOfWork.GetRepository<Product, int>().GetAsync(id);

            if (product is null) return null;

            _mapper.Map(dto, product); // maps dto object to product object

            _unitOfWork.GetRepository<Product, int>().Update(product);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductDto>(product);
        }
    }
}
