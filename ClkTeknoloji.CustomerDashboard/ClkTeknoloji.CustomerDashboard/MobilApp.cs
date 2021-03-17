using System;
using System.Net.Http;
using ClkTeknoloji.Shared.Service.Users;
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


                    var apiUri = "http://f35de6cf486f.ngrok.io"; //Buraya ip adresi girilmeli
                    services.AddScoped(sp =>
                    {
                        var client = new HttpClient
                        {
                            BaseAddress = new Uri(apiUri)
                        };

                        return client;
                    });

                    services.AddScoped<IUserService, UserService>();


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
