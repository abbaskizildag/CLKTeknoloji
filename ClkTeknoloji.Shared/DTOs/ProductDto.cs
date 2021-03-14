using System;
using System.Collections.Generic;
using System.Text;

namespace ClkTeknoloji.Shared.DTOs
{
   public class ProductDto
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedUserId { get; set; }
        public string Type { get; set; }
        public string Information { get; set; }
        public string PartOfProduct { get; set; }
        public string Statu { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpireDate { get; set; }
        public int CustomerId { get; set; }
    }
}
