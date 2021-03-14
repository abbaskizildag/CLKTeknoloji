using System;
using System.Collections.Generic;
using System.Text;

namespace ClkTeknoloji.Shared.DTOs
{
    public class UserLoginResponse
    {
        public string ApiToken { get; set; }
        public UserDto User { get; set; }
    }
}
