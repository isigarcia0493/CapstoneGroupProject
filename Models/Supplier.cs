using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Models
{
    public class Supplier
    {
        public int SupplierID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Supplier Address")]
        public string Address { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "Supplier Phone Number")]
        public string PhoneNumber { get; set; }

        [StringLength(25)]
        [Display(Name = "Supplier Email")]
        public string Email { get; set; }


    }
}
