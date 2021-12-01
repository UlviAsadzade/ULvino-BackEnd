using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public int Order { get; set; }

        [StringLength(maximumLength: 100)]
        public string Image { get; set; }

        [StringLength(maximumLength: 100)]
        public string Name { get; set; }

        [StringLength(maximumLength: 100)]
        public string Owner { get; set; }

        [StringLength(maximumLength: 500)]
        public string Desc { get; set; }

        public DateTime Date { get; set; }
    }
}
