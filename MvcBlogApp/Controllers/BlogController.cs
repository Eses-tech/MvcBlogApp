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

            return View(_context.Blogs.OrderByDescending(c=> c.UploadDate).ToList());
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "CategoryName");

            return View();
        }

        [HttpPost]
        public ActionResult Create(string Header, string Explanation, string Picture, string Content, int CategoryId)
        {

            Blog _blog = new Blog();
            _blog.Header = Header;
            _blog.Explanation = Explanation;
            _blog.Picture = Picture;
            _blog.Content = Content;
            _blog.CategoryId = CategoryId;
            _blog.UploadDate = DateTime.Now;
            _context.Blogs.Add(_blog);
            _context.SaveChanges();



            return RedirectToAction("Index","Blog");
        }

    }
}