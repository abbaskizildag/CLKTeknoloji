using ClkTeknoloji.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClkTeknoloji.Shared.Service.Customers
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
