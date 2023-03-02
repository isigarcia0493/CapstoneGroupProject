using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [StringLength(50)]
        [Display(Name = "Product Name")]
        public string Description { get; set; }

        [Required]
        [Range(0, 99.99)]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        public int SupplierID { get; set; }

        public int CategoryID { get; set; }


    }
}
