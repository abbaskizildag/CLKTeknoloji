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
    public class CustomerController : ControllerBase
    {
                private readonly ICustomerService customerService;
        
        public CustomerController(ICustomerService ProductService)
        {
            customerService = ProductService;
        }
        [HttpGet("Customers")]
        public async Task<ServiceResponse<List<CustomerDto>>> GetAllCustomers()
        {
            return new ServiceResponse<List<CustomerDto>>
            {
                Value = await customerService.GetAllCustomer()
            };
        }

        [HttpPost("Create")]
        public async Task<ServiceResponse<CustomerDto>> CreateCustomer([FromBody] CustomerDto Customer)
        {
            return new ServiceResponse<CustomerDto>
            {
                Value = await customerService.CreateCustomer(Customer)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<CustomerDto>> UpdateCustomer([FromBody] CustomerDto Customer)
        {
            return new ServiceResponse<CustomerDto>
            {
                Value = await customerService.UpdateCustomer(Customer)
            };
        }

        [HttpGet("CustomerById/{Id}")]
        public async Task<ServiceResponse<CustomerDto>> GetCustomertById(int Id)
        {
            return new ServiceResponse<CustomerDto>
            {
                Value = await customerService.GetCustomerById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteCustomer([FromBody] int Id)
        {
            return new ServiceResponse<bool>
            {
                Value = await customerService.DeleteCustomerById(Id)
            };
        }

    }
}
