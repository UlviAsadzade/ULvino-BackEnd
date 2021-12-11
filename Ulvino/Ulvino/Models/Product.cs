using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int VariatyId { get; set; }
        public Variaty Variaty { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        public int TypeId { get; set; }
        public Type Type { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }

        [Required]
        public double CostPrice { get; set; }

        [Required]
        public double SalePrice { get; set; }

        [StringLength(maximumLength: 500)]
        public string Desc { get; set; }

        [Required]
        public bool IsFeatured { get; set; }

        [Required]
        public int Rate { get; set; }

        public DateTime Vintage { get; set; }

        public bool IsDeleted { get; set; }

        public List<ProductImage> ProductImages { get; set; }


        [NotMapped]
        public IFormFile PosterFile { get; set; }

        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }

        [NotMapped]
        public List<int> ProductImageIds { get; set; } = new List<int>();


    }
}
