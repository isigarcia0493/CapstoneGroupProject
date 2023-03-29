﻿using CapstoneGroupProject.Helpers;
using CapstoneGroupProject.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Enter a employee first name")]
        [StringLength(50)]
        [DisplayName("Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter a employee last name")]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(14)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100)]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(100)]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(50)]
        [DisplayName("State")]
        public string State { get; set; }


        [Required(ErrorMessage = "Zip Code is required")]
        [StringLength(5)]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Hire Date is required")]
        [DisplayName("Hire Date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [DisplayName("Is employee active")]
        public bool IsActive { get; set; }

        public IEnumerable<IOrderedQueryable> Orders { get; set; }

        public IEnumerable<SelectListItem> States
        {
            get
            {
                var options = new List<SelectListItem>();

                foreach (States option in Enum.GetValues(typeof(States)))
                {
                    options.Add(new SelectListItem()
                    {
                        Text = AttributeExtentions.GetDescription(option),
                        Value = option.ToString(),
                    });
                }
                return options;
            }
        }
    }
}

