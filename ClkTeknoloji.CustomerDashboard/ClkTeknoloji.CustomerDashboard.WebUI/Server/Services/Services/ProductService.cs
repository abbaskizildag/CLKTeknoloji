﻿using AutoMapper;
using AutoMapper.Configuration;
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
    public class ProductService : IProductService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;


        public ProductService(AppDbContext Context, IMapper Mapper)
        {
            context = Context;
            mapper = Mapper;
        }
        public async Task<ProductDto> CreateProduct(ProductDto Product)
        {
            var dbProduct = await context.Products.Where(i => i.Id == Product.Id).FirstOrDefaultAsync();
            if (dbProduct != null)
            {
                throw new Exception("İlgili kayıt zaten mevcut");
            }

            Product.CreateDate = DateTime.Now;
            Product.Statu = "Yapılıyor";
            dbProduct = mapper.Map<ClkTeknoloji.Server.Data.Models.Product>(Product);
            await context.Products.AddAsync(dbProduct);
            await context.SaveChangesAsync();
            return mapper.Map<ProductDto>(dbProduct);
        }

        public async Task<bool> DeleteProductById(int Id)
        {
            var dbProduct = await context.Products.FirstOrDefaultAsync(i => i.Id == Id);
            if (dbProduct == null)
            {
                throw new Exception("Kayıt bulunanamadı");
            }
            context.Products.Remove(dbProduct);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<ProductDto>> GetAllProduct()
        {
            var products = await context.Products.Include(x => x.Service).Include(x=>x.Customer).ToListAsync();
            return mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductById(int Id)
        {
            var product = await context.Products.Where(i => i.Id == Id).Include(x => x.Service).Include(x => x.Customer).FirstOrDefaultAsync();
            return mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProduct(ProductDto Product)
        {
            var dbProduct = await context.Products.Where(i => i.Id == Product.Id).FirstOrDefaultAsync();
            if (dbProduct == null)
            {
                throw new Exception("İlgili kayıt bulunamadı");
            }
            var dbCustomer = await context.Customers.Where(i=>i.Id == Product.CustomerId).FirstOrDefaultAsync();
            if (dbCustomer ==null)
            {
                //işlem yapılacak
            }

            dbProduct.Customer = dbCustomer;
           // mapper.Map(Product, dbProduct);
            context.Products.Update(dbProduct);
            await context.SaveChangesAsync();
            return mapper.Map<ProductDto>(dbProduct);
        }
    }
}