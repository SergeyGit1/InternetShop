using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetShop.Entities
{
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Cost { get; set; }
    }
}