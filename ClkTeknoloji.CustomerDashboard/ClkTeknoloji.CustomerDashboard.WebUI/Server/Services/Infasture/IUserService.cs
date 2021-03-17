using ClkTeknoloji.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClkTeknoloji.CustomerDashboard.WebUI.Server.Services.Infasture
{
   public interface IUserService
    {
        public Task<UserDto> GetUserById(int Id);
        public Task<List<UserDto>> GetUser();
        public Task<UserDto> CreateUser(UserDto User);
        public Task<UserDto> UpdateUser(UserDto User);
        public Task<bool> DeleteUserById(int Id);
        public Task<UserLoginResponse> Login(UserLoginRequest userLoginRequest);
    }
}
