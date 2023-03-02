using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Order Details")]
        public string OrderDetails { get; set; }

        [Required]
        [Range(0, 999.99)]
        [Display(Name = "Order Total")]
        public decimal OrderTotal { get; set; }


    }
}
