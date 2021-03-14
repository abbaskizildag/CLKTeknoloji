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

    }
}
