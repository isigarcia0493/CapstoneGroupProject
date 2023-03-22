using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneGroupProject.Models;
using CapstoneGroupProject.ViewModels;
using CapstoneGroupProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Controllers
{

 

    public class ProductController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult CreateProduct()
        {
            return View();
        }
        
        public ActionResult ListProducts()
        {
            var products = ToViewModel(_appDbContext.Products.ToList());
            return View(products);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(ProductViewModel vmProduct)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    ProductID = vmProduct.ProductID,
                    ProductName = vmProduct.ProductName,
                    Description = vmProduct.Description,
                    UnitPrice = vmProduct.UnitPrice,
                    Quantity = vmProduct.Quantity,
                    SupplierID = vmProduct.SupplierID,
                    CategoryID = vmProduct.CategoryID
                };

                //How it goes to DB                
                await _appDbContext.AddAsync(product);
                await _appDbContext.SaveChangesAsync();

                //This shows it in a red message on the screen
                ModelState.AddModelError(string.Empty, "Product was successfully added");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Couldn't add Product to database");
            }
            return View();
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpDelete]
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

        public List<ViewModels.ProductViewModel> ToViewModel(List<Product> productList)
        {
            var vmList = new List<ProductViewModel>();
            foreach (Product product in productList)
            {
                ProductViewModel vmProduct = new ProductViewModel();
                vmProduct.ProductID = product.ProductID;
                vmProduct.ProductName = product.ProductName;
                vmProduct.Description = product.Description;
                vmProduct.UnitPrice = product.UnitPrice;
                vmProduct.Quantity = product.Quantity;
                vmProduct.Supplier = product.Supplier;
                vmProduct.Category = product.Category;
                vmList.Add(vmProduct);
            }

            return vmList;
        }
    }
}
