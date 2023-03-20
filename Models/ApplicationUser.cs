using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        IEnumerable<Employee> Employees { get; set; }
    }
}
