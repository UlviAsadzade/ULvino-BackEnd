using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.Models
{
    public class ProductImage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


        [StringLength(maximumLength: 100)]
        public string Image { get; set; }

        public bool IsPoster { get; set; }

    }
}
