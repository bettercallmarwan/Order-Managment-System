using AutoMapper;
using Business_Layer.Dtos;
using Data_Access_Layer.Models;

namespace Business_Layer.Mapping    
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<Order, OrderDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductDto, Product>().ReverseMap();
            //CreateMap<Order, OrderDetailsDto>();

            CreateMap<Order, OrderDetailsDto>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.Name : string.Empty))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems));

            CreateMap<OrderItem, OrderItemDto>();


        }
    }
}
