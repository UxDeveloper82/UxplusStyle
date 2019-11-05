using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UxDesignPlusStyle.Models;

namespace UxDesignPlusStyle.Controllers
{
    [Authorize]
    public class MyPortfolioController : Controller
    {
        private ApplicationDbContext _context;

        public MyPortfolioController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: MyPortfolio
        [AllowAnonymous]
        public ActionResult Index()
        {
            var myports = _context.MyPortfolio;
            return View(myports);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var myport = _context.MyPortfolio.SingleOrDefault(p => p.Id == id);
            if (myport == null)
                return HttpNotFound();
            return View(myport);
        }

        public ActionResult New()
        {
          
            return View("New");
        }



        [HttpPost]
        public ActionResult Save(MyPortfolio myPortfolio)
        {
            if (myPortfolio.Id == 0)
            {
                _context.MyPortfolio.Add(myPortfolio);
            }
            else
            {
                var myPortfolioInDb = _context.MyPortfolio.Single(p => p.Id == myPortfolio.Id);
                myPortfolioInDb.Id = myPortfolio.Id;
                myPortfolioInDb.Title = myPortfolio.Title;
                myPortfolioInDb.imageUrl = myPortfolio.imageUrl;
                myPortfolioInDb.Type = myPortfolio.Type;
                myPortfolioInDb.Description = myPortfolio.Description;
            } 
            _context.SaveChanges();
            return RedirectToAction("Index","MyPortfolio");
        }
        

        public ActionResult Edit(int id)
        {
            var myport = _context.MyPortfolio.SingleOrDefault(p => p.Id == id);

            if (myport == null)
                return HttpNotFound();
            return View("New", myport);
        }

        private IEnumerable<MyPortfolio> GetMyPortfolios()
        {
            return new List<MyPortfolio>
            {
                new MyPortfolio { Id = 1 , Title= "First Title"},
                new MyPortfolio { Id= 2 , Title= "Second Title"},
                new MyPortfolio { Id = 3, Title = "Third Title"}

            };

        }
    }
}