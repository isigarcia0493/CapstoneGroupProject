using CapstoneGroupProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.ViewModels.Order
{
    public class OrderViewModel
    {
        [Key]
        public int OrderID { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "There is not total")]
        [Range(0, 999.99)]
        [DisplayName("Order Total")]
        [Column(TypeName = "decimal(20,2)")]

        public decimal OrderTotal { get; set; }

        [DisplayName("Employee")]
        public string EmployeeName { get; set; }

        [DisplayName("Ordered Items")]
        public List<ProductViewModel> OrderProducts { get; set; }

        public string productDescriptions { get; set; }
    }
}
