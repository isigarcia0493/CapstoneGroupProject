using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Category Description")]
        public string CategoryDescription { get; set; }


    }
}
