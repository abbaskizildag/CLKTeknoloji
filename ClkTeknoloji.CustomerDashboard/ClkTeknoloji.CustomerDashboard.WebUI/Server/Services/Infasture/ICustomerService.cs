using ClkTeknoloji.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClkTeknoloji.CustomerDashboard.WebUI.Server.Services.Infasture
{
    public interface ICustomerService
    {
        public Task<CustomerDto> GetCustomerById(int Id);
        public Task<List<CustomerDto>> GetAllCustomer();
        public Task<CustomerDto> CreateCustomer(CustomerDto Customer);
        public Task<CustomerDto> UpdateCustomer(CustomerDto Customer);
        public Task<bool> DeleteCustomerById(int Id);
    }
}
