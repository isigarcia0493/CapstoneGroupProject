using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CapstoneGroupProject.Models;
using CapstoneGroupProject.ViewModels;
using CapstoneGroupProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CapstoneGroupProject.Controllers
{
    public class SupplierController : Controller
    {
        //inject DB
        private readonly AppDbContext _appDbContext;

        //new constructor for DB
        public SupplierController(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }
        // GET: SupplierController
        public IActionResult IndexSupplier()
        {
            try
            {
                var suppliers = _appDbContext.Suppliers.ToList();
                return View(suppliers);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // GET: SupplierController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: SupplierController/Create
        public IActionResult CreateSupplier()
        {
            SupplierViewModel supplierVM = new SupplierViewModel();

            return View(supplierVM);
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateSupplier(Supplier model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _appDbContext.Suppliers.AddAsync(model);
                    _appDbContext.SaveChanges();
                    ModelState.AddModelError(string.Empty, "Supplier was successfully added");
                    return RedirectToAction("IndexSupplier");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Couldn't add supplier to database");
                    throw new Exception(ex.ToString());
                }
            }
            else
            {
                return View(model);
            }

        }

        // GET: SupplierController/Edit/5
        public IActionResult EditSupplier(int id)
        {
            try
            {
                var supplier = _appDbContext.Suppliers.Find(id);

                SupplierViewModel supplierVM = new SupplierViewModel()
                {
                    SupplierID = supplier.SupplierID,
                    SupplierName = supplier.SupplierName,
                    Address = supplier.Address,
                    City = supplier.City,
                    State = supplier.State,
                    ZipCode = supplier.ZipCode,
                    PhoneNumber = supplier.PhoneNumber,
                    Email = supplier.Email
                };

                return View(supplierVM);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSupplier(Supplier model)
        {
            try
            {
                _appDbContext.Entry(model).State = EntityState.Modified;
                _appDbContext.SaveChanges();
                return RedirectToAction("IndexSupplier");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: SupplierController/Delete/5
        public IActionResult DeleteSupplier(int id)
        {
            try
            {
                var supplier = _appDbContext.Suppliers.Find(id);

                return View(supplier);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // POST: SupplierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSupplier(Supplier model)
        {
            try
            {
                var supplier = _appDbContext.Suppliers.Find(model.SupplierID);
                _appDbContext.Remove(supplier);
                _appDbContext.SaveChanges();

                return RedirectToAction("IndexSupplier");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}
