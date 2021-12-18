using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models.Enums;

namespace Ulvino.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }

        [StringLength(maximumLength: 250)]
        public string Address { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 25)]
        public string Phone { get; set; }

        [StringLength(maximumLength: 500)]
        public string Note { get; set; }

        [StringLength(maximumLength: 50)]
        public string City { get; set; }

        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
        public double TotalAmount { get; set; }
        public AppUser AppUser { get; set; }

        public List<OrderItem> OrderItems { get; set; }


    }
}
