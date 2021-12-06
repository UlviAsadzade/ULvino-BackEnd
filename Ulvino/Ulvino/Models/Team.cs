using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.Models
{
    public class Team
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 100)]
        public string Image { get; set; }

        [StringLength(maximumLength: 100)]
        public string FullName { get; set; }

        [StringLength(maximumLength: 50)]
        public string Profession { get; set; }

        [StringLength(maximumLength: 100)]
        public string FacebookUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string TwitterUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string GooglePlusUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string PinterestUrl { get; set; }
    }
}
