using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClkTeknoloji.CustomerDashboard.WebUI.Shared.DTOs
{
    public class UserLoginResponse
    {
        public string ApiToken { get; set; }
        public UserDto User { get; set; }
    }
}
