using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneGroupProject.Models;
using CapstoneGroupProject.ViewModels;
using Microsoft.IdentityModel.Protocols;

namespace CapstoneGroupProject.Controllers
{
    public class SupplierController : Controller
    {
        // GET: SupplierController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SupplierController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupplierController/Create
        public ActionResult CreateSupplier()
        {
            return View();
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSupplier(SupplierViewModel vmSupplier)
        {
            if (ModelState.IsValid)
            {
                Supplier supplier = new Supplier();
                supplier.SupplierName = vmSupplier.SupplierName;
                supplier.Address = vmSupplier.Address;
                supplier.City = vmSupplier.City;
                supplier.Email = vmSupplier.Email;
                supplier.PhoneNumber = vmSupplier.PhoneNumber;
                supplier.State = vmSupplier.State;
                supplier.ZipCode = vmSupplier.ZipCode;

                // Send to DB
                
            }
            return View();
        }

        // GET: SupplierController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupplierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
