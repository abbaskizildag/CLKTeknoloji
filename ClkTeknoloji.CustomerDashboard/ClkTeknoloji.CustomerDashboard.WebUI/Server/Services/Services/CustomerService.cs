using AutoMapper;
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
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public CustomerService(AppDbContext Context, IMapper Mapper)
        {
            context = Context;
            mapper = Mapper;
        }
        public async Task<CustomerDto> CreateCustomer(CustomerDto Customer)
        {
            var dbCustomer = await context.Customers.Where(i => i.Id == Customer.Id).FirstOrDefaultAsync();
            if (dbCustomer != null)
            {
                throw new Exception("İlgili kayıt zaten mevcut");
            }
            Customer.CreateDate = DateTime.Now;
            dbCustomer = mapper.Map<ClkTeknoloji.Server.Data.Models.Customer>(Customer);
            await context.Customers.AddAsync(dbCustomer);
            await context.SaveChangesAsync();
            return mapper.Map<CustomerDto>(dbCustomer);
        }

        public async Task<bool> DeleteCustomerById(int Id)
        {
            var dbCustomer = await context.Customers.FirstOrDefaultAsync(i => i.Id == Id);
            if (dbCustomer == null)
            {
                throw new Exception("Kayıt bulunanamadı");
            }
            context.Customers.Remove(dbCustomer);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<CustomerDto>> GetAllCustomer()
        {
            var customers = await context.Customers.Include(x => x.Products).ToListAsync();
            return mapper.Map<List<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetCustomerById(int Id)
        {
            var customer = await context.Customers.Where(i => i.Id == Id).Include(x => x.Products).FirstOrDefaultAsync();
            return mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> UpdateCustomer(CustomerDto Customer)
        {
            var dbCustomer = await context.Customers.Where(i => i.Id == Customer.Id).FirstOrDefaultAsync();
            if (dbCustomer == null)
            {
                throw new Exception("İlgili kayıt bulunamadı");
            }

            mapper.Map(Customer, dbCustomer);
            context.Customers.Update(dbCustomer);
            await context.SaveChangesAsync();
            return mapper.Map<CustomerDto>(dbCustomer);
        }
    }
}
