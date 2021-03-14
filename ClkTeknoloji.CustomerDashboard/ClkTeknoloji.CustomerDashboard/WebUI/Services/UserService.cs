using ClkTeknoloji.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClkTeknoloji.CustomerDashboard.WebUI.Services
{
     class UserService 
    {
        private readonly HttpClient httpClient;

        public UserService(HttpClient HttpClient)
        {
            this.httpClient = HttpClient;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<UserDto>>(await httpClient.GetStreamAsync($"api/user/users"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
