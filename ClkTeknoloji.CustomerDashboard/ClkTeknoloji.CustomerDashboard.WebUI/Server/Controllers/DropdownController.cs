using ClkTeknoloji.CustomerDashboard.WebUI.Server.Services.Infasture;
using ClkTeknoloji.Shared.DTOs;
using ClkTeknoloji.Shared.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClkTeknoloji.CustomerDashboard.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController : ControllerBase
    {
        private readonly IServiceService serviceService;

        public DropdownController(IServiceService ServiceService)
        {
            serviceService = ServiceService;
        }
        [HttpGet("Services")]
        public async Task<ServiceResponse<List<ServiceDto>>> GetAllCustomers()
        {
            return new ServiceResponse<List<ServiceDto>>
            {
                Value = await serviceService.GetAllService()
            };
        }
    }
}
