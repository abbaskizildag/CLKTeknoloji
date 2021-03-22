using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClkTeknoloji.Server.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedUserId { get; set; }
        public int ServiceId { get; set; }
        public string Type { get; set; }
        public string Information { get; set; }
        public string PartOfProduct { get; set; }
        public string Statu { get; set; }
        public decimal? Price { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int? CustomerId { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Service Service { get; set; }

    }
}
