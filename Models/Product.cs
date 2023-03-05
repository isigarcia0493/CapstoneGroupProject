using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Enter a product name")]
        [StringLength(50)]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [StringLength(50)]
        [Display(Name = "Product Name")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter a unit price")]
        [Range(0, 99.99)]
        [DisplayName("Unit Price")]
        [Column(TypeName = "decimal(20,2)")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Enter Quantity")]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }


        //Relationships
        public int SupplierID { get; set; }
        [ForeignKey("SupplierID")]
        public Supplier Supplier { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
    }
}
