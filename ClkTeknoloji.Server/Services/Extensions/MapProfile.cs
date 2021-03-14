using AutoMapper;
using ClkTeknoloji.Server.Data.Models;
using ClkTeknoloji.Shared.DTOs;

namespace ClkTeknoloji.Server.Services.Extensions
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}
