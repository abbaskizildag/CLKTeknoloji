using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ClkTeknoloji.Shared.DTOs
{
   public class UserLoginRequest
    {

        [Required(ErrorMessage = "Bu alan zorunludur.")]

        public string EMail { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]

        public string Password { get; set; }
    }
}
