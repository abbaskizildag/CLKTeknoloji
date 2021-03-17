using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClkTeknoloji.CustomerDashboard.WebUI.Shared.Utilis
{
    public class PasswordEncrypter
    {
        public static string Encrypt(string Password)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(Password);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
