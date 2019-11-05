using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UxDesignPlusStyle.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult TodoList()
        {
            return View();
        }

        // GET: Projects
        public ActionResult BookMarker()
        {
            return View();
        }

        public ActionResult Budgety()
        {
            return View();
        }
    }
}