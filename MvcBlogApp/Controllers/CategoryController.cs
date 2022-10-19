using MvcBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private BlogContext _context = new BlogContext();
       
        public ActionResult Index()
        {
            List<Category> categorylist = _context.Categories.ToList();
            List<int> categorynumbers = new List<int>();
            for (int i = 0; i < categorylist.Count; i++)
            {
                int a = _context.Blogs.Where(b => b.CategoryId == categorylist[i].Id).Count();
                categorynumbers.Add(a);
            }

            ViewBag.CategoryNumbers = categorynumbers;
            return View(categorylist.OrderByDescending(c=>c.Id).ToList());

        }

        
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string CategoryName)
        {
            Category _category = new Category();
            _category.CategoryName = CategoryName;
            _context.Categories.Add(_category);
            _context.SaveChanges();
            return RedirectToAction("Index","Category");
        }


        public ActionResult Edit(int id)
        {
            Category _category = _context.Categories.Find(id);
           
            return View(_category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,string CategoryName)
        {
            Category _category = _context.Categories.Find(id);
            _category.CategoryName = CategoryName;
            _context.SaveChanges();

            TempData["Category"] = _category;
            return RedirectToAction("Index","Category");
        }

        public PartialViewResult CategoryList()
        {
            return PartialView(_context.Categories.ToList());
        }
    }
}