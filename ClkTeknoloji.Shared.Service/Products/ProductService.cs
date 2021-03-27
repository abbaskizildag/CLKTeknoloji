using ClkTeknoloji.Shared.DTOs;
using ClkTeknoloji.Shared.FilterModels;
using ClkTeknoloji.Shared.ResponseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClkTeknoloji.Shared.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ProductDto> CreateProduct(ProductDto Product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/product/create", Product);

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<ProductDto>>(resultString);

            if (!result.Success)
            {
                throw new Exception(result.Message);
            }

            return result.Value;
        }

        public async Task<bool> DeleteProductById(int Id)
        {
            var response = await _httpClient.PostAsJsonAsync("api/product/delete", Id);

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<bool>>(resultString);

            if (!result.Success)
            {
                throw new Exception(result.Message);
            }

            return result.Value;
        }

        public async Task<List<ProductDto>> GetAllProduct()
        {
            var response = await _httpClient.GetAsync("api/product/products");

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<List<ProductDto>>>(resultString);

            if (!result.Success)
            {

            }

            return result.Value;
        }

        public async Task<List<ProductDto>> GetProductByFilter(ProductListFilterModel filter)
        {
            var response = await _httpClient.PostAsJsonAsync("api/product/filter",filter);

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<List<ProductDto>>>(resultString);

            if (!result.Success)
            {

            }

            return result.Value;
        }

        public async Task<ProductDto> GetProductById(int Id)
        {
            var response = await _httpClient.GetAsync($"api/product/ProductById/{Id}");

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<ProductDto>>(resultString);

            if (!result.Success)
            {

            }

            return result.Value;
        }

        public async Task<ProductDto> UpdateProduct(ProductDto Product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/product/update", Product);

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<ProductDto>>(resultString);

            if (!result.Success)
            {
                throw new Exception(result.Message);
            }

            return result.Value;
        }
    }
}
