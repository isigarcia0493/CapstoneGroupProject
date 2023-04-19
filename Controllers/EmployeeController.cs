using CapstoneGroupProject.Data;
using CapstoneGroupProject.Models;
using CapstoneGroupProject.Models.Enums;
using CapstoneGroupProject.ViewModels.Employee;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public EmployeeController(AppDbContext appDbContext, UserManager<IdentityUser> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            try
            {
                var employees = _appDbContext.Employees.ToList();             

                return View(employees);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }           
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var employee = _appDbContext.Employees.Find(id);

                return View(employee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            EmployeeViewModel model = new EmployeeViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _userManager.Users.Where(ue => ue.Email == model.Email).FirstOrDefault();

                    if(user != null)
                    {
                        model.UserID = user.Id;
                        _appDbContext.Employees.AddAsync(model);
                        _appDbContext.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    else{
                        EmployeeViewModel employeeVM = new EmployeeViewModel() { 
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            PhoneNumber = model.PhoneNumber,
                            Address = model.Address,
                            City = model.City,
                            State = model.State,
                            ZipCode = model.ZipCode,
                            IsActive = model.IsActive
                        };

                        ModelState.AddModelError("", "Email not found!");

                        return View(employeeVM);
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            else
            {
                return View(model);
            }                     
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            try
            {
                var employee = _appDbContext.Employees.Find(id);

                EmployeeViewModel employeeVM = new EmployeeViewModel()
                {
                    EmployeeID = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    PhoneNumber = employee.PhoneNumber,
                    Email = employee.Email,
                    Address = employee.Address,
                    City = employee.City,
                    State = employee.State,
                    ZipCode = employee.ZipCode,
                    HireDate = employee.HireDate,
                    IsActive = employee.IsActive
                };

                return View(employeeVM);

            }catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _appDbContext.Entry(model).State = EntityState.Modified;
                    _appDbContext.SaveChanges();

                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var employee = _appDbContext.Employees.Find(id);

                return View(employee);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(Employee model)
        {
            try
            {
                var employee = _appDbContext.Employees.Find(model.EmployeeID);
                var user = await _userManager.FindByIdAsync(employee.UserID);

                if(user == null)
                {
                    return RedirectToAction("Error", "Home");
                }
                else
                {
                    var result = await _userManager.DeleteAsync(user);
                    _appDbContext.Remove(employee);
                    _appDbContext.SaveChanges();

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
