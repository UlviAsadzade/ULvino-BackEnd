using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;
using Type = Ulvino.Models.Type;

namespace Ulvino.ViewModels
{
    public class ProductViewModel
    {
        public List<Variaty> Variaties { get; set; }
        public List<Type> Types { get; set; }
        public List<Region> Regions { get; set; }
        public List<Product> Products { get; set; }
    }
}
