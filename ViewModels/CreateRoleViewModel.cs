using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CapstoneGroupProject.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "Enter role name")]
        [DisplayName("Role Name")]
        public string RoleName { get; set; }
    }
}
