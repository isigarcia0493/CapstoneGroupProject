using CapstoneGroupProject.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var employees = _appDbContext.Employees.ToList();

            return View(employees);
        }
    }
}
