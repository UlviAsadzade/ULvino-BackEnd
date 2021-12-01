using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.Models
{
    public class Slider
    {
        public int Id { get; set; }

        public int Order { get; set; }


        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
    }
}
