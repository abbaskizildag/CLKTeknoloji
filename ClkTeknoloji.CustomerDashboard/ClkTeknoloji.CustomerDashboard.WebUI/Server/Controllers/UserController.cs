using ClkTeknoloji.CustomerDashboard.WebUI.Server.Services.Infasture;
using ClkTeknoloji.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClkTeknoloji.Shared.ResponseModels;

namespace ClkTeknoloji.CustomerDashboard.WebUI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService UserService)
        {
            this.userService = UserService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ServiceResponse<UserLoginResponse>> Login(UserLoginRequest userLoginRequest)
        {
            return new ServiceResponse<UserLoginResponse>()
            {
                Value = await userService.Login(userLoginRequest)
            };
        }

        [HttpGet("Users")]
        public async Task<ServiceResponse<List<UserDto>>> GetUsers()
        {
            return new ServiceResponse<List<UserDto>>
            {
                Value = await userService.GetUser()
            };
        }

        [HttpPost("Create")]
        public async Task<ServiceResponse<UserDto>> CreateUser([FromBody] UserDto User)
        {
            return new ServiceResponse<UserDto>
            {
                Value = await userService.CreateUser(User)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<UserDto>> UpdateUser([FromBody] UserDto User)
        {
            return new ServiceResponse<UserDto>
            {
                Value = await userService.UpdateUser(User)
            };
        }

        [HttpGet("UserById/{Id}")]
        public async Task<ServiceResponse<UserDto>> GetUserById(int Id)
        {
            return new ServiceResponse<UserDto>
            {
                Value = await userService.GetUserById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteUser([FromBody] int Id)
        {
            return new ServiceResponse<bool>
            {
                Value = await userService.DeleteUserById(Id)
            };
        }
    }
}
