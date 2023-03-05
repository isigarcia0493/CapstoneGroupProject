using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required(ErrorMessage = "Enter a payment Type")]
        [StringLength(50)]
        [DisplayName("Payment Type")]
        public string PaymentType { get; set; }

        //Relationships
        public int OrderID { get; set; }

        [ForeignKey("OrderID")]
        public Order Order { get; set; }
    }
}
