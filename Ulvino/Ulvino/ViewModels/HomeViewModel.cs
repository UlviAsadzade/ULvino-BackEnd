using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;

namespace Ulvino.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Product> FeaturedProducts { get; set; }
        public List<Product> PopularProducts { get; set; }
        public List<Customer> Customers { get; set; }
        public Setting Settings { get; set; }

    }
}
