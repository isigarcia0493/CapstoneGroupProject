using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CapstoneGroupProject.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        public string RoleId { get; set; }

        [Required(ErrorMessage = "Enter a role name")]
        [DisplayName("Role Name")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
