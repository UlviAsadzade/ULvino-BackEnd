using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;

namespace Ulvino.ViewModels
{
    public class ReviewViewModel
    {
        public Product Product { get; set; }
        public List<Review> Reviews { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
    }
}
