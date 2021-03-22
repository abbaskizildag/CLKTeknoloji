using ClkTeknoloji.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClkTeknoloji.CustomerDashboard.WebUI.Server.Services.Infasture
{
    public interface IProductService
    {
        public Task<ProductDto> GetProductById(int Id);
        public Task<List<ProductDto>> GetAllProduct();
        public Task<ProductDto> CreateProduct(ProductDto Product);
        public Task<ProductDto> UpdateProduct(ProductDto Product);
        public Task<bool> DeleteProductById(int Id);
    }
}
