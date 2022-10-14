using MvcBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogApp.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog

        private BlogContext _context = new BlogContext();

        public ActionResult Index()
        {
            List<string> categorylist = new List<string>();
            foreach (var item in _context.Blogs.ToList())
            {
                categorylist.Add(_context.Categories.Find(item.CategoryId).CategoryName);
                
            }

            ViewBag.CategoryNames = categorylist;

            return View(_context.Blogs.ToList());
        }

        public ActionResult Create()
        {
            List<string> categorylist = new List<string>();
            foreach (var item in _context.Blogs.ToList())
            {
                categorylist.Add(_context.Categories.Find(item.CategoryId).CategoryName);

            }

            ViewBag.CategoryNames = categorylist;

            return View(_context.Blogs.ToList());
        }
    }
}