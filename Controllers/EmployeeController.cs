using CapstoneGroupProject.Data;
using CapstoneGroupProject.Models;
using CapstoneGroupProject.Models.Enums;
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

        public EmployeeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
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
            Employee model = new Employee();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {
                try
                {                    
                    _appDbContext.Employees.AddAsync(model);
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
        public IActionResult Edit(int id) 
        {
            try
            {
                var employee = _appDbContext.Employees.Find(id);

                return View(employee);

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
        public IActionResult Delete(Employee model)
        {
            try
            {
                var employee = _appDbContext.Employees.Find(model.EmployeeID);
                _appDbContext.Remove(employee);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
