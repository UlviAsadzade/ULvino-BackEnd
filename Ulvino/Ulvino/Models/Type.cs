using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.Models
{
    public class Type
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }

    }
}
