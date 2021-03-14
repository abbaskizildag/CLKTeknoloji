using System;
using System.Collections.Generic;
using System.Text;

namespace ClkTeknoloji.Server.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMailAddress { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
