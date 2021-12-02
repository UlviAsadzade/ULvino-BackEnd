using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.Models
{
    public class Faq
    {
        public int Id { get; set; }

        public int Order { get; set; }

        [StringLength(maximumLength: 250)]
        public string Question { get; set; }

        [StringLength(maximumLength: 250)]
        public string Answer { get; set; }

      



    }
}
