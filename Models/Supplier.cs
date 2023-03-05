using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "Enter a supplier name")]
        [StringLength(100)]
        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "Enter the supplier address")]
        [StringLength(100)]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter city")]
        [StringLength(100)]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter State")]
        [StringLength(20)]
        [DisplayName("State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Enter Zip Code")]
        [DisplayName("Zip Code")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "Enter a phone number")]
        [StringLength(14)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter an email")]
        [StringLength(50)]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
    }
}
