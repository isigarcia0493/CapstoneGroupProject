using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }

        public int OrderID { get; set; }
    }
}
