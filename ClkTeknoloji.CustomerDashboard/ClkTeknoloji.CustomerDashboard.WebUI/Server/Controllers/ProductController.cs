using ClkTeknoloji.CustomerDashboard.WebUI.Server.Services.Infasture;
using ClkTeknoloji.Shared.DTOs;
using ClkTeknoloji.Shared.FilterModels;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService ProductService)
        {
            productService = ProductService;
        }
        [HttpGet("Products")]
        public async Task<ServiceResponse<List<ProductDto>>> GetAllProducts()
        {
            return new ServiceResponse<List<ProductDto>>
            {
                Value = await productService.GetAllProduct()
            };
        }

        [HttpPost("Create")]
        public async Task<ServiceResponse<ProductDto>> CreateProduct([FromBody] ProductDto Product)
        {
            return new ServiceResponse<ProductDto>
            {
                Value = await productService.CreateProduct(Product)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<ProductDto>> UpdateProduct([FromBody] ProductDto Product)
        {
            return new ServiceResponse<ProductDto>
            {
                Value = await productService.UpdateProduct(Product)
            };
        }

        [HttpGet("ProductById/{Id}")]
        public async Task<ServiceResponse<ProductDto>> GetProductById(int Id)
        {
            return new ServiceResponse<ProductDto>
            {
                Value = await productService.GetProductById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteProduct([FromBody] int Id)
        {
            return new ServiceResponse<bool>
            {
                Value = await productService.DeleteProductById(Id)
            };
        }

        [HttpPost("Filter")]
        public async Task<ServiceResponse<List<ProductDto>>> GetProductByFilter([FromBody] ProductListFilterModel Filter)
        {
            return new ServiceResponse<List<ProductDto>>
            {
                Value = await productService.GetProductByFilter(Filter)
            };
        }
    }
}
