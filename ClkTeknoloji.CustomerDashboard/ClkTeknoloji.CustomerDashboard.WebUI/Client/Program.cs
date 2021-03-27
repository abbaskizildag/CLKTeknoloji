using Blazored.LocalStorage;
using Blazored.Modal;
using ClkTeknoloji.CustomerDashboard.Utilis;
using ClkTeknoloji.Shared.Service.Customers;
using ClkTeknoloji.Shared.Service.DropDowns;
using ClkTeknoloji.Shared.Service.Products;
using ClkTeknoloji.Shared.Service.Users;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClkTeknoloji.CustomerDashboard.WebUI.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<ClkTeknoloji.CustomerDashboard.WebUI.App>("app");
            builder.Services.AddBlazoredModal();
            builder.Services.AddScoped<ModalManager>();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredModal();
            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IDropDownService, DropDownService>();
            builder.Services.AddAntDesign();


            builder.Services.AddSingleton(sp => new CounterState());
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

            await builder.Build().RunAsync();
        }
    }
}
