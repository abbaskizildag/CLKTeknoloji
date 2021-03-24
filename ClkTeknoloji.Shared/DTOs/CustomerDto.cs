using System;
using System.Collections.Generic;
using System.Text;

namespace ClkTeknoloji.Shared.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public virtual ICollection<ProductDto> Products { get; set; }

    }
}
