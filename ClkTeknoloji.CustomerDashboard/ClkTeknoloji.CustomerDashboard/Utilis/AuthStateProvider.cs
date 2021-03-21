using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClkTeknoloji.CustomerDashboard.Utilis
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorageService;
        private readonly HttpClient httpClient;
        private readonly AuthenticationState anonymous; //1-boş bir kullanıcı oluşturduk
        public AuthStateProvider(ILocalStorageService LocalStorageService, HttpClient HttpClient)
        {
            localStorageService = LocalStorageService;
            httpClient = HttpClient;
            anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));  //2-ilk başta bu şekilde set ediyoruz
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string apiToken = await localStorageService.GetItemAsStringAsync("token");


            if (string.IsNullOrEmpty(apiToken))
                return anonymous;

            string email = await localStorageService.GetItemAsStringAsync("email");

            var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType")); //burada claim içerisine email bilgisini atadık

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

            return new AuthenticationState(cp);
        }

        public void NotifyUserLogin(string email) //giriş yapıldıktan sonra tetikleniyor
        {
            var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(cp));
            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
