using System;
using System.Net.Http;
using Blazored.LocalStorage;
using Blazored.Modal;
using ClkTeknoloji.CustomerDashboard.Utilis;
using ClkTeknoloji.Shared.Service.Customers;
using ClkTeknoloji.Shared.Service.DropDowns;
using ClkTeknoloji.Shared.Service.Products;
using ClkTeknoloji.Shared.Service.Users;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.MobileBlazorBindings;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ClkTeknoloji.CustomerDashboard
{
    public class MobilApp : Application
    {
        public MobilApp(IFileProvider fileProvider = null)
        {
            var hostBuilder = MobileBlazorBindingsHost.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    // Adds web-specific services such as NavigationManager
                    services.AddBlazorHybrid();


                    var apiUri = "https://kizildag.developcu.com/"; //Buraya ip adresi girilmeli
                    services.AddScoped(sp =>
                    {
                        var client = new HttpClient
                        {
                            BaseAddress = new Uri(apiUri)
                        };

                        return client;
                    });
                    services.AddAuthorizationCore();
                    services.AddScoped<AuthStateProvider>();
                    services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<AuthStateProvider>());
                    services.AddBlazoredModal();
                    services.AddBlazoredLocalStorage();
                    services.AddAntDesign();

                    services.AddSingleton<IUserService, UserService>();
                    services.AddSingleton<IProductService, ProductService>();
                    services.AddSingleton<ICustomerService, CustomerService>();
                    services.AddSingleton<IDropDownService, DropDownService>();





                    // Register app-specific services
                    services.AddSingleton<CounterState>();
                })
                .UseWebRoot("wwwroot");

            if (fileProvider != null)
            {
                hostBuilder.UseStaticFiles(fileProvider);
            }
            else
            {
                hostBuilder.UseStaticFiles();
            }
            var host = hostBuilder.Build();

            MainPage = new ContentPage { Title = "My Application" };
            host.AddComponent<Main>(parent: MainPage);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
