using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lungisa.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // Loads the Homepage view
        public ActionResult Index()
        {
            return View();
        }

        // Loads the About Us page
        public ActionResult About()
        {
            return View();
        }

        // Loads the Contact Us page
        public ActionResult Contact()
        {
            return View();
        }

        // Loads the Latest News page
        public ActionResult News()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Donations()
        {
            return View();
        }
    }
}