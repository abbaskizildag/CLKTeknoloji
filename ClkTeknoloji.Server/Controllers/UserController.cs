using AutoMapper;
using ClkTeknoloji.Server.Data.Models;
using ClkTeknoloji.Server.Services.Infasture;
using ClkTeknoloji.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClkTeknoloji.Server.Controllers
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
        public async Task<UserLoginResponse> Login(UserLoginRequest userLoginRequest)
        {
            return await userService.Login(userLoginRequest);
        }

        [HttpGet("Users")]
        public async Task<List<UserDto>> GetUsers()
        {
            return await userService.GetUser();
        }
        [HttpPost("Create")]
        public async Task<UserDto> CreateUser([FromBody] UserDto User)
        {
            return await userService.CreateUser(User);
        }
        [HttpPost("Update")]
        public async Task<UserDto> UpdateUser([FromBody] UserDto User)
        {
            return await userService.UpdateUser(User);
        }
        [HttpGet("UserById/{Id}")]
        public async Task<UserDto> GetUserById(int Id)
        {
            return await userService.GetUserById(Id);
        }
        [HttpPost("Delete")]
        public async Task<bool> DeleteUser([FromBody] int Id)
        {
            return await userService.DeleteUserById(Id);
        }
    }
}
