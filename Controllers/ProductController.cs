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
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewBag.Categories = GetCategories();
            ViewBag.Suppliers = GetSuppliers();

            return View();
        }

        public IEnumerable<SelectListItem> GetCategories()
        {
            return _appDbContext.Categories.Select(c => new SelectListItem()
            {
                Text = c.CategoryName,
                Value = c.CategoryID.ToString(),
            }).ToList();
        }

        public IEnumerable<SelectListItem> GetSuppliers()
        {
            return _appDbContext.Suppliers.Select(c => new SelectListItem()
            {
                Text = c.SupplierName,
                Value = c.SupplierID.ToString(),
            }).ToList();
        }

        public IActionResult ListProducts()
        {
            var products = ToViewModel(_appDbContext.Products.ToList());
            foreach (var item in products)
            {
                item.Category = _appDbContext.Categories.Where(c => c.CategoryID == item.CategoryID).FirstOrDefault();
                item.Supplier = _appDbContext.Suppliers.Where(s => s.SupplierID == item.SupplierID).FirstOrDefault();
                item.TotalCost = Convert.ToDecimal(item.Quantity) * Convert.ToDecimal(item.UnitPrice);
            }
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
                
                return RedirectToAction("ListProducts");
            }
            else
            {
                ViewBag.Categories = GetCategories();
                ViewBag.Suppliers = GetSuppliers();
                ModelState.AddModelError(string.Empty, "Couldn't add Product to database");
                
                return View(vmProduct);
            }
        }

        // GET: ProductController/Edit/5
        public IActionResult EditProduct(int id)
        {
            ProductViewModel vmProduct = new ProductViewModel();
            try
            {
                var product = _appDbContext.Products.Find(id);
                vmProduct = ModelToVM(product);
                ViewBag.Categories = GetCategories();
                ViewBag.Suppliers = GetSuppliers();

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
                return RedirectToAction("ListProducts");
            }
            catch
            {
                ViewBag.Categories = GetCategories();
                ViewBag.Suppliers = GetSuppliers();

                return View(vmProduct);
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult DeleteProduct(int id)
        {
            var product = _appDbContext.Products.Find(id);
            
            product.Category = _appDbContext.Categories.Find(product.CategoryID);
            product.Supplier = _appDbContext.Suppliers.Find(product.SupplierID);

            return View("DeleteProductView", product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduct(Product model)
        {
            try
            {
                var product = _appDbContext.Products.Find(model.ProductID);

                if(product != null)
                {
                    _appDbContext.Products.Remove(product);
                    _appDbContext.SaveChanges();

                    return RedirectToAction("ListProducts");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
