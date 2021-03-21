using ClkTeknoloji.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClkTeknoloji.Shared.Service.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsers();

        Task<UserLoginResponse> UserLogin(UserLoginRequest userLoginRequest);

        public Task<UserDto> GetUserById(int Id);
        public Task<UserDto> CreateUser(UserDto User);
        public Task<UserDto> UpdateUser(UserDto User);
        public Task<bool> DeleteUserById(int Id);

    }
}
