using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.ViewModels
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [DisplayName("Email")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "The confirmation password does not match the password")]
        public string PasswordConfirmation { get; set; }
    }
}
