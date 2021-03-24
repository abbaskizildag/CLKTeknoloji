using AutoMapper;
using ClkTeknoloji.CustomerDashboard.WebUI.Server.Services.Infasture;
using ClkTeknoloji.Server.Data.Context;
using ClkTeknoloji.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClkTeknoloji.CustomerDashboard.WebUI.Server.Services.Services
{
    public class ServiceService : IServiceService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;


        public ServiceService(AppDbContext Context, IMapper Mapper)
        {
            context = Context;
            mapper = Mapper;
        }
        public async Task<List<ServiceDto>> GetAllService()
        {
            var services = await context.Services.ToListAsync();
            return mapper.Map<List<ServiceDto>>(services);
        }
    }
}
