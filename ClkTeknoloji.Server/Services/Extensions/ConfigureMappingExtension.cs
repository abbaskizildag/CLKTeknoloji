using AutoMapper;
using ClkTeknoloji.Server.Data.Models;
using ClkTeknoloji.Shared.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClkTeknoloji.Server.Services.Extensions
{
    public static class ConfigureMappingExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            IMapper mapper = mappingConfig.CreateMapper();
            service.AddSingleton(mapper);
            return service;
        }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            CreateMap<User, UserDto>().ReverseMap();



        }
    }
}
