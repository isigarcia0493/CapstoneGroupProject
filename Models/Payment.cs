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

        [DisplayName("Cash Paid")]
        [Column(TypeName = "decimal(20,2)")]
        public decimal CashTotal { get; set; }

        [StringLength(100)]
        [DisplayName("Name in Card")]
        public string NameIntheCard { get; set; }

        [StringLength(20)]
        [DisplayName("Card Number")]
        public string CardNumber { get; set; }

        [StringLength(5)]
        [DisplayName("Expiration Date")]
        public string ExpitarionDate { get; set; }

        [StringLength(3)]
        [DisplayName("Security Code")]
        public string SecurityCode { get; set; }

        //Relationships
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }
    }
}
