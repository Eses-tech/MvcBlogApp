using MvcBlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            BlogContext _context = new BlogContext();
            var blogs = _context.Blogs.Select(b => new BlogModel()
            {
                Id = b.Id,
                Approval = b.Approval,
                CategoryId = b.CategoryId,
                Explanation = b.Explanation,
                Header = b.Header.Length>100?b.Header.Substring(0,100):b.Header,
                HomePage = b.HomePage,
                Picture = b.Picture,
                UploadDate = b.UploadDate

            })
                .Where(b => b.HomePage == true && b.Approval == true).OrderByDescending(b=>b.UploadDate).ToList();


            return View(blogs.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}