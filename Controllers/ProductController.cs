using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneGroupProject.Models;
using CapstoneGroupProject.ViewModels;
using CapstoneGroupProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult EditProduct(int id)
        {
            ProductViewModel vmProduct = new ProductViewModel();
            try
            {
                var product = _appDbContext.Products.Find(id);
                vmProduct = ModelToVM(product);
                return View(vmProduct);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(int id, ProductViewModel vmProduct)
        {
            try
            {
                var test = VMToModel(vmProduct);
                _appDbContext.Entry(test).State = EntityState.Modified;
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
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
                vmProduct.SupplierID = product.SupplierID;
                vmProduct.CategoryID = product.CategoryID;
                vmList.Add(vmProduct);
            }

            return vmList;
        }
        public static Product VMToModel(ProductViewModel vmProduct)
        {
            Product product = new Product();
            product.ProductID = vmProduct.ProductID;
            product.ProductName = vmProduct.ProductName;
            product.Description = vmProduct.Description;
            product.UnitPrice = vmProduct.UnitPrice;
            product.Quantity = vmProduct.Quantity;
            product.SupplierID = vmProduct.SupplierID;
            product.CategoryID = vmProduct.CategoryID;
            

            return product;
        }
        public static ProductViewModel ModelToVM(Product product)
        {
            ProductViewModel vmproduct = new ProductViewModel();
            vmproduct.ProductID = product.ProductID;
            vmproduct.ProductName = product.ProductName;
            vmproduct.Description = product.Description;
            vmproduct.UnitPrice = product.UnitPrice;
            vmproduct.Quantity = product.Quantity;
            vmproduct.SupplierID = product.SupplierID;
            vmproduct.CategoryID = product.CategoryID;


            return vmproduct;
        }
    }
}
