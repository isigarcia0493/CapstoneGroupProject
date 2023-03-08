using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        //Relationships
        [ForeignKey("ID")]
        public string ID { get; set; }

        //Add other employee information in here.
        //First/LastName/IsActive/HireDate/etc

    }
}
