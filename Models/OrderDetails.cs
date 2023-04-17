using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailID { get; set; }

        [Required(ErrorMessage = "Enter order price")]
        [Range(0, 999.99)]
        [DisplayName("Order Price")]
        [Column(TypeName = "decimal(20,2)")]
        public decimal OrderPrice { get; set; }

        [Required(ErrorMessage = "Enter quantity")]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "There is not total")]
        [Range(0, 99999.99)]
        [DisplayName("Total")]
        [Column(TypeName = "decimal(20,2)")]
        public decimal Total { get; set; }

        public int ProductId { get; set; }

        //Relationships
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
