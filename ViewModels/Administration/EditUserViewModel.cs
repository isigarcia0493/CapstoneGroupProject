using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace CapstoneGroupProject.ViewModels.Administration
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [DisplayName("Email")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Confirmation Email is Required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [DisplayName("Email Confirmation")]
        public string Email { get; set; }
    }
}
