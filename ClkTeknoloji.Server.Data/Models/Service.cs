using System;
using System.Collections.Generic;
using System.Text;

namespace ClkTeknoloji.Server.Data.Models
{
   public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Product Product { get; set; }

    }
}
