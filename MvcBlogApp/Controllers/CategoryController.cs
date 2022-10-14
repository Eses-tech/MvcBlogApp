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
            return View(categorylist);

        }
    }
}