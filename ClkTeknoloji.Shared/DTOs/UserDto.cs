using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClkTeknoloji.Shared.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]

        public string EMailAddress { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]

        public string Password { get; set; }

        public string FullName => $"{FirstName} {LastName}";

    }
}
