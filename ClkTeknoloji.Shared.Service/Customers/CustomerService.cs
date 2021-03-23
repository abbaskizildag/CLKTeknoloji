using ClkTeknoloji.Shared.DTOs;
using ClkTeknoloji.Shared.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClkTeknoloji.Shared.Service.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CustomerDto> CreateCustomer(CustomerDto Customer)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customer/create", Customer);

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<CustomerDto>>(resultString);

            if (!result.Success)
            {
                throw new Exception(result.Message);
            }

            return result.Value;
        }

        public async Task<bool> DeleteCustomerById(int Id)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customer/delete", Id);

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<bool>>(resultString);

            if (!result.Success)
            {
                throw new Exception(result.Message);
            }

            return result.Value;
        }

        public async Task<List<CustomerDto>> GetAllCustomer()
        {
            var response = await _httpClient.GetAsync("api/customer/customers");

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<List<CustomerDto>>>(resultString);

            if (!result.Success)
            {

            }

            return result.Value;
        }

        public async Task<CustomerDto> GetCustomerById(int Id)
        {
            var response = await _httpClient.GetAsync($"api/customer/customerById/{Id}");

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<CustomerDto>>(resultString);

            if (!result.Success)
            {

            }

            return result.Value;
        }

        public async Task<CustomerDto> UpdateCustomer(CustomerDto Customer)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customer/update", Customer);

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<CustomerDto>>(resultString);

            if (!result.Success)
            {
                throw new Exception(result.Message);
            }

            return result.Value;
        }
    }
}
