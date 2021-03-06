using ClkTeknoloji.Shared.DTOs;
using ClkTeknoloji.Shared.FilterModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClkTeknoloji.Shared.Service.Products
{
   public interface IProductService
    {
        public Task<ProductDto> GetProductById(int Id);
        public Task<List<ProductDto>> GetAllProduct();
        public Task<ProductDto> CreateProduct(ProductDto Product);
        public Task<ProductDto> UpdateProduct(ProductDto Product);
        public Task<bool> DeleteProductById(int Id);
        public Task<List<ProductDto>> GetProductByFilter(ProductListFilterModel filter);
    }
}
