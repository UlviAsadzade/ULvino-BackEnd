using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.Models
{
    public class Feature
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 100)]
        public string Title { get; set; }

        [StringLength(maximumLength: 200)]
        public string Desc { get; set; }

        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
    }
}
