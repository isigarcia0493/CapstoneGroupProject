using CapstoneGroupProject.Data;
using CapstoneGroupProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneGroupProject.Controllers
{
    public class CategoryController : Controller
    {
        //inject DB
        private readonly AppDbContext _appDbContext;

        //new constructor for DB
        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        // GET: CategoryController
        public IActionResult IndexCategory()
        {
            try
            {
                var categories = _appDbContext.Categories.ToList();
                return View(categories);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // GET: CategoryController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public IActionResult CreateCategory()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _appDbContext.Categories.AddAsync(model);
                    _appDbContext.SaveChanges();
                    ModelState.AddModelError(string.Empty, "Category was successfully added");
                    return RedirectToAction("IndexCategory");
                }
                catch (Exception ex)
                {
                    //May need to check here if category id already exists
                    //Tell user category already exists
                    ModelState.AddModelError(string.Empty, "Couldn't add category to database");
                    throw new Exception(ex.ToString());
                }
            }
            else
            {
                return View(model);
            }
        }

        // GET: CategoryController/Edit/5
        public IActionResult EditCategory(int id)
        {
            try
            {
                var category = _appDbContext.Categories.Find(id);

                return View(category);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(Category model)
        {
            try
            {
                _appDbContext.Entry(model).State = EntityState.Modified;
                _appDbContext.SaveChanges();
                return RedirectToAction("IndexCategory");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: CategoryController/Delete/5
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var category = _appDbContext.Categories.Find(id);

                return View(category);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(Category model)
        {
            try
            {
                var category = _appDbContext.Categories.Find(model.CategoryID);
                //Need to check if a product ID exists in category, if it does we can't remove it
                //If no products exist then the category can be removed.
                if(category.Product != null)
                {
                    ModelState.AddModelError(string.Empty, "Couldn't remove category from database");
                    return RedirectToAction("IndexCategory");
                }
                else
                {
                    _appDbContext.Remove(category);
                    _appDbContext.SaveChanges();

                    return RedirectToAction("IndexCategory");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
