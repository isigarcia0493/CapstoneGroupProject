using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CapstoneGroupProject.Models;
using CapstoneGroupProject.ViewModels;
using CapstoneGroupProject.Data;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Index()
        {
            return View();
        }

        // GET: SupplierController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: SupplierController/Create
        public IActionResult CreateSupplier()
        {
            return View();
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSupplier(SupplierViewModel vmSupplier)
        {
            if (ModelState.IsValid)
            {
                Supplier supplier = new Supplier
                {
                    SupplierName = vmSupplier.SupplierName,
                    Address = vmSupplier.Address,
                    City = vmSupplier.City,
                    Email = vmSupplier.Email,
                    PhoneNumber = vmSupplier.PhoneNumber,
                    State = vmSupplier.State,
                    ZipCode = vmSupplier.ZipCode
                };

                //How it goes to DB                
                await _appDbContext.AddAsync(supplier);
                await _appDbContext.SaveChangesAsync();

                //This shows it in a red message on the screen
                ModelState.AddModelError(string.Empty, "Supplier was successfully added");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Couldn't add supplier to database");
            }
            return View();
        }

        // GET: SupplierController/Edit/5
        public IActionResult EditSupplier(int id)
        {
            return View();
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSupplier(int id, SupplierViewModel vmSupplier)
        {
            try
            {
                var test = VMToModel(vmSupplier);
                _appDbContext.Entry(test).State = EntityState.Modified;
                _appDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierController/Delete/5
        public IActionResult DeleteSupplier(int id)
        {
            return View();
        }

        // POST: SupplierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSupplier(int id, IFormCollection collection)
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

        public static ViewModels.SupplierViewModel ModelToVM(Supplier supplier)
        {
            ViewModels.SupplierViewModel vmSupplier = new SupplierViewModel();
            supplier.SupplierID = vmSupplier.SupplierID;
            supplier.SupplierName = vmSupplier.SupplierName;
            supplier.Address = vmSupplier.Address;
            supplier.City = vmSupplier.City;
            supplier.Email = vmSupplier.Email;
            supplier.PhoneNumber = vmSupplier.PhoneNumber;
            supplier.State = vmSupplier.State;
            supplier.ZipCode = vmSupplier.ZipCode;

            return vmSupplier;
        }

        public static Supplier VMToModel(SupplierViewModel vmSupplier)
        {
            Supplier supplier = new Supplier();
            vmSupplier.SupplierID = supplier.SupplierID;
            vmSupplier.SupplierName = supplier.SupplierName;
            vmSupplier.Address = supplier.Address;
            vmSupplier.City = supplier.City;
            vmSupplier.Email = supplier.Email;
            vmSupplier.PhoneNumber = supplier.PhoneNumber;
            vmSupplier.State = supplier.State;
            vmSupplier.ZipCode = supplier.ZipCode;

            return supplier;
        }
    }
}
