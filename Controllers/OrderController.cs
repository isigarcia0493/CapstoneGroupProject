using CapstoneGroupProject.Data;
using CapstoneGroupProject.Models;
using CapstoneGroupProject.ViewModels.Order;
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

        //new constructor for DB
        public OrderController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: OrderController
        public ActionResult IndexOrder()
        {

            return View();
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //GET
        public ActionResult AllOrders()
        {
            try
            {
                var orders = _appDbContext.Orders.ToList();
                List<OrderViewModel> ordersVM = new List<OrderViewModel>();
                foreach (Order order in orders)
                {
                    ordersVM.Add(OrderToOrderVM(order));
                }
                return View(ordersVM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        // GET: OrderController/Create
        public IActionResult CreateOrder()
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
                    OrderDetails = vmOrder.OrderDetails,
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

        private OrderViewModel OrderToOrderVM(Order order)
        {
            OrderViewModel orderVM = new OrderViewModel
            {
                OrderID = order.OrderID,
                OrderDate = order.OrderDate,
                OrderTotal = order.OrderTotal,
                OrderDetails = order.OrderDetails
            };
            return orderVM;
        }

        private Order OrderVMToOrder (OrderViewModel orderVM)
        {
            Order order = new Order
            {
                OrderID = orderVM.OrderID,
                OrderDate = orderVM.OrderDate,
                OrderTotal = orderVM.OrderTotal,
                OrderDetails = orderVM.OrderDetails
            };
            return order;
        }
    }
}
