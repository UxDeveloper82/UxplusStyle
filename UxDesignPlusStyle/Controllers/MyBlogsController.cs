using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UxDesignPlusStyle.Models;

namespace UxDesignPlusStyle.Controllers
{
    [Authorize]
    public class MyBlogsController : Controller
    {
        private ApplicationDbContext _context;

        public MyBlogsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: MyBlogs
        [AllowAnonymous]
        public ActionResult Index()
        {
            var myBlogs = _context.MyBlogs;
            return View(myBlogs);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var myBlog = _context.MyBlogs.SingleOrDefault(b => b.Id == id);

            return View(myBlog);
        }

        public ActionResult New()
        {
            return View("New");
        }

        [HttpPost]
        public ActionResult Save(MyBlog myBlog)
        {
            if (myBlog.Id == 0) {
                _context.MyBlogs.Add(myBlog);
            }
            else {
                var myBlogInDb = _context.MyBlogs.Single(b => b.Id == myBlog.Id);
                myBlogInDb.Id = myBlog.Id;
                myBlogInDb.Title = myBlog.Title;
                myBlogInDb.Author = myBlog.Author;
                myBlogInDb.imageUrl = myBlog.imageUrl;
                myBlogInDb.DatePost = myBlog.DatePost;
                myBlogInDb.Description = myBlog.Description;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "MyBlogs");
        }

        public ActionResult Edit(int id)
        {
            var myBlog = _context.MyBlogs.SingleOrDefault(b => b.Id == id);
            if (myBlog == null)
                return HttpNotFound();
            return View("New", myBlog);
        }
    }
}