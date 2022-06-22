using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_FrontToBack.ViewModels
{
    public class ProductReturnVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
