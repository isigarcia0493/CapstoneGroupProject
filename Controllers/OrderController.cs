using CapstoneGroupProject.Data;
using CapstoneGroupProject.Models;
using CapstoneGroupProject.ViewModels;
using CapstoneGroupProject.ViewModels.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly SignInManager<IdentityUser> _signInManager;



        //new constructor for DB
        public OrderController(AppDbContext appDbContext, SignInManager<IdentityUser> signInManager)
        {
            _appDbContext = appDbContext;
            _signInManager = signInManager;
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
                decimal grandTotal = 0;

                foreach (Order order in orders)
                {
                    var orderDetails = _appDbContext.OrderDetails.Where(od => od.OrderId == order.OrderID);
                    string productDescription = "";
                    int num = 0;
                    foreach (var item in orderDetails)
                    {
                        var productDetails = _appDbContext.Products.Where(pd => pd.ProductID == item.ProductId).FirstOrDefault();
                        if (num == 0)
                        {
                            productDescription += item.Quantity.ToString() + " " + productDetails.ProductName;
                        }
                        else
                        {
                            productDescription += ", " + item.Quantity.ToString() + " " + productDetails.ProductName;
                        }
                        num++;
                    }
                    grandTotal += order.OrderTotal;
                    ordersVM.Add(OrderToOrderVM(order, productDescription));
                }
                ViewBag.GrandTotal = grandTotal.ToString("c2");
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
        public IActionResult CreateOrder(List<ProductViewModel> products)
        {
            List<ProductViewModel> selectedProducts = new List<ProductViewModel>();
            decimal orderTotal = 0;
            foreach (ProductViewModel product in products)
            {
                
                if (product.IsChecked)
                {
                    selectedProducts.Add(product);
                }
            }
            foreach(ProductViewModel product in selectedProducts)
            {
                orderTotal += (product.UnitPrice * product.OrderQuantity); 
            }
            if (ModelState.IsValid)
            {
                
                /*var user = _userManager.Users.Where(ue => ue.Email == model.Email).FirstOrDefault();*/


                Order order = new Order
                {

                    OrderDate = DateTime.Now,
                    OrderTotal = orderTotal,
                    OrderProducts = selectedProducts,

                };

                //How it goes to DB                
                

                //This shows it in a red message on the screen
                ModelState.AddModelError(string.Empty, "Order was successfully added");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Couldn't add order to database");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                await _appDbContext.AddAsync(order);
                await _appDbContext.SaveChangesAsync();
                ModelState.AddModelError(string.Empty, "Order was successfully added");
            } else
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

        [HttpGet]
        public IActionResult AddToList(int id)
        {
            var product = _appDbContext.Products.Find(id);

            if (product != null)
            {
     
                ProductListViewModel productListVM = new ProductListViewModel()
                {
                    ProductId = product.ProductID,
                    ProductName = product.ProductName,
                    Price = product.UnitPrice,
                };

                return View(productListVM);

            }
            else
            {
                return RedirectToAction("Error", "Home");
            }


        }

        [HttpPost]
        public IActionResult AddToList(ProductListViewModel model)
        {
            if(model.Quantity == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
            OrderList orderList = new OrderList
                {
                    ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    Total = (model.Quantity * model.Price)
                };

                _appDbContext.OrderLists.Add(orderList);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult DeleteProduct(int id) 
        {
            var product = _appDbContext.OrderLists.Find(id);

            if(product != null)
            {
                _appDbContext.OrderLists.Remove(product);
                _appDbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult CheckOut(decimal total)
        {
            Order order = new Order();
            Payment payment = new Payment();

            PaymentViewModel paymentVM = new PaymentViewModel(order, payment);

            paymentVM.Order.OrderDate = DateTime.Now;
            paymentVM.Order.OrderTotal = total;

            return View(paymentVM);
        }

        [HttpPost]
        public IActionResult CheckOut(PaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(_signInManager.IsSignedIn(User))
                {
                    var employee = _appDbContext.Employees.Where(en => en.Email == User.Identity.Name).SingleOrDefault();
                    Order order = new Order()
                    {
                        OrderDate = model.Order.OrderDate,
                        OrderTotal = model.Order.OrderTotal,
                        Employee = employee,
                        EmployeeId = employee.EmployeeID,                        
                    };
                    _appDbContext.Orders.Add(order);
                    _appDbContext.SaveChanges();

                    Payment payment = new Payment()
                    {
                        PaymentType = model.Payment.PaymentType,
                        CashTotal = model.Order.OrderTotal,
                        NameIntheCard = model.Payment.NameIntheCard,
                        CardNumber = model.Payment.CardNumber,
                        ExpitarionDate = model.Payment.ExpitarionDate,
                        SecurityCode = model.Payment.SecurityCode,
                        OrderID = order.OrderID,
                        Order = _appDbContext.Orders.Find(model.Order.OrderID)
                    };

                    _appDbContext.Payments.Add(payment);
                    _appDbContext.SaveChanges();

                    var products = _appDbContext.OrderLists.ToList();

                    if(products != null)
                    {
                        foreach(var product in products)
                        {
                            try
                            {
                                OrderDetails orderDetails = new OrderDetails();

                                orderDetails.OrderPrice = product.Price;
                                orderDetails.Quantity = product.Quantity;
                                orderDetails.Total = product.Total;
                                orderDetails.OrderId = order.OrderID;
                                orderDetails.ProductId = product.ProductId;

                                _appDbContext.OrderDetails.Add(orderDetails);
                                _appDbContext.SaveChanges();

                                _appDbContext.Remove(product);
                                _appDbContext.SaveChanges();
                            
                            }catch(Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                        }

                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }



                return View();
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
        }

        private OrderViewModel OrderToOrderVM(Order order, string productDescription = "")
        {
            OrderViewModel orderVM = new OrderViewModel
            {
                OrderID = order.OrderID,
                OrderDate = order.OrderDate,
                OrderTotal = order.OrderTotal,
                OrderProducts = order.OrderProducts,
                productDescriptions = productDescription
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
                OrderProducts = orderVM.OrderProducts
            };
            return order;
        }


    }
}
