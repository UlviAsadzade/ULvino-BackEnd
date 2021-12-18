using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int Count { get; set; }

        [StringLength(maximumLength: 100)]
        public string ProductName { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
