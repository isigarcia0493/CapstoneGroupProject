﻿using CapstoneGroupProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneGroupProject.Models
{
    public class Order
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

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public List<ProductViewModel> OrderProducts { get; set; }
    }
}
