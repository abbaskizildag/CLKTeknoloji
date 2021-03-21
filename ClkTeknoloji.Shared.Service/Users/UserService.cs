using ClkTeknoloji.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClkTeknoloji.Shared.BPResponse;
using System.Net.Http.Json;
using ClkTeknoloji.Shared.ResponseModels;

namespace ClkTeknoloji.Shared.Service.Users
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDto> CreateUser(UserDto User)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user/create", User);

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<UserDto>>(resultString);

            if (!result.Success)
            {
                throw new Exception(result.Message);
            }

            return result.Value;
        }

        public async Task<bool> DeleteUserById(int Id)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user/delete", Id);

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<bool>>(resultString);

            if (!result.Success)
            {
                throw new Exception(result.Message);
            }

            return result.Value;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var response = await _httpClient.GetAsync("api/user/users");

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<List<UserDto>>>(resultString);

            if (!result.Success)
            {

            }

            return result.Value;
        }

        public async Task<UserDto> GetUserById(int Id)
        {
            var response = await _httpClient.GetAsync($"api/user/UserById/{Id}");

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<UserDto>>(resultString);

            if (!result.Success)
            {

            }

            return result.Value;
        }

        public async Task<UserDto> UpdateUser(UserDto User)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user/update", User);

            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<UserDto>>(resultString);

            if (!result.Success)
            {
                throw new Exception(result.Message);
            }

            return result.Value;
        }

        public async Task<UserLoginResponse> UserLogin(UserLoginRequest userLoginRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user/login", userLoginRequest);
 
            var resultString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServiceResponse<UserLoginResponse>>(resultString);

            if (!result.Success)
            {
               throw new Exception(result.Message);
            }

            return result.Value;
        }
    }
}
