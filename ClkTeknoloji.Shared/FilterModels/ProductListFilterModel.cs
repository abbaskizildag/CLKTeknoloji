using System;
using System.Collections.Generic;
using System.Text;

namespace ClkTeknoloji.Shared.FilterModels
{
   public class ProductListFilterModel
    {
        public DateTime? CreateDateFirst { get; set; }
        public DateTime CreateDateLast { get; set; }
        public int CreatedUserId { get; set; }

        public int CustomerId { get; set; }

        public string Type { get; set; }
        public string Statu { get; set; }

        public int ServiceId { get; set; }
    }
}
