using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.Models
{
    public class Process
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 100)]
        public string Icon { get; set; }

        [StringLength(maximumLength: 100)]
        public string Title { get; set; }
    }
}
