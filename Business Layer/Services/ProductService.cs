using AutoMapper;
using Business_Layer.Dtos;
using Business_Layer.Services.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.UnitOfWork;

namespace Business_Layer.Services
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<Product> AddProductAsync(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _unitOfWork.GetRepository<Product, int>().AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return product;
        }

        public async Task<ProductDto> GetProductAsync(int id)
        {
            var product = await _unitOfWork.GetRepository<Product, int>().GetAsync(id);
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
            var repo = _unitOfWork.GetRepository<Product, int>();
            var product = await repo.GetAsync(id);

            if (product == null)
                return null;

            _mapper.Map(dto, product);

            repo.Update(product);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<ProductDto>(product);



        }

    }
}
