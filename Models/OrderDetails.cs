using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Models
{
    public class OrderDetails
    {
        public int OrderDetailID { get; set; }

        [Required]
        [Range(0, 999.99)]
        [Display(Name = "Order Price")]
        public decimal OrderPrice { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Range(0, 999.99)]
        [Display(Name = "Total")]
        public decimal Total { get; set; }

    }
}
