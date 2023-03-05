using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Enter Category Name")]
        [StringLength(100)]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Enter Description")]
        [StringLength(100)]
        [DisplayName("Description")]
        public string CategoryDescription { get; set; }

        public IEnumerable<Product> Product { get; set; }
    }
}
