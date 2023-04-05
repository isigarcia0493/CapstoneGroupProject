using CapstoneGroupProject.Data;
using CapstoneGroupProject.Models;
using CapstoneGroupProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var productList = ToViewModel(_appDbContext.Products.ToList());
            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
    }
}
