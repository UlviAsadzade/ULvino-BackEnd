using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.ViewModels
{
    public class WishlistItemViewModel
    {
        public int ProductId { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
    }
}
