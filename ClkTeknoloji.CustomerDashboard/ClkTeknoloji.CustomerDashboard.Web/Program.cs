using ClkTeknoloji.Shared.Service.Users;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClkTeknoloji.CustomerDashboard.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<ClkTeknoloji.CustomerDashboard.WebUI.App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped(sp =>
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:8784")
                };

                return client;
            });
            //  builder.Services.AddHttpClient<IUserService, UserService>(client=> client.BaseAddress = new Uri("https://localhost:44328/"));

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddSingleton(sp => new CounterState());

            //builder.Services.AddScoped<IUserService, OrderService>();

            WebAssemblyHost host = builder.Build();
            await host.RunAsync();
        }
    }
}
