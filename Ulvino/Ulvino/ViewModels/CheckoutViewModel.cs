using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.ViewModels
{
    public class CheckoutViewModel
    {
        public List<BasketItemViewModel> BasketItemViewModels { get; set; } = new List<BasketItemViewModel>();

        [Required]
        [StringLength(maximumLength: 50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 25)]
        public string Phone { get; set; }

        [Required]
        [StringLength(maximumLength: 250)]
        public string Address { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string City { get; set; }
        
        [StringLength(maximumLength: 500)]
        public string Note { get; set; }
    }
}
