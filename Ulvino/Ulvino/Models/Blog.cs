using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [StringLength(maximumLength: 100)]
        public string Name { get; set; }

        [StringLength(maximumLength: 100)]
        public string Owner { get; set; }

        [StringLength(maximumLength: 1000)]
        public string Desc1 { get; set; }

        [StringLength(maximumLength: 1000)]
        public string Desc2 { get; set; }

        [StringLength(maximumLength: 1000)]
        public string Desc3 { get; set; }

        [StringLength(maximumLength: 1000)]
        public string Desc4 { get; set; }

        [StringLength(maximumLength: 1000)]
        public string Desc5 { get; set; }

        public DateTime Date { get; set; }
    }
}
