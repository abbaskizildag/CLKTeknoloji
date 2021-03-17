using ClkTeknoloji.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClkTeknoloji.Shared.BPResponse;
using System.Net.Http.Json;

namespace ClkTeknoloji.Shared.Service.Users
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var response = await _httpClient.GetAsync("api/user/users");

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<UserDto>>(resultString);

            if (result == null)
            {

            }

            return result;

          //  return await _httpClient.GetFromJsonAsync<IEnumerable<UserDto>>("api/user/users");

        }

        public async Task<UserLoginResponse> UserLogin(UserLoginRequest userLoginRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user/login", userLoginRequest);

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<UserLoginResponse>(resultString);

            if (result==null)
            {
              // throw result.Error;
            }

            return result;
        }
    }
}
