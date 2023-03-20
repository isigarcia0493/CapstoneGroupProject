using CapstoneGroupProject.Data;
using CapstoneGroupProject.Models;
using CapstoneGroupProject.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Controllers
{
    public class OrderController : Controller
    {
        //inject DB
        private readonly AppDbContext _appDbContext;

        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder(OrderViewModel vmOrder)
        {
            if (ModelState.IsValid)
            {
                Order order = new Order
                {
                    OrderID = vmOrder.OrderID,
                    OrderDate = vmOrder.OrderDate,
                    OrderTotal = vmOrder.OrderTotal,
                    OrderDetails = vmOrder.OrderDetails
                };

                //How it goes to DB                
                await _appDbContext.AddAsync(order);
                await _appDbContext.SaveChangesAsync();

                //This shows it in a red message on the screen
                ModelState.AddModelError(string.Empty, "Order was successfully added");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Couldn't add order to database");
            }
            return View();
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
