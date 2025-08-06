using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lungisa.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminDashboard()
        {
            return View();
        }
        public ActionResult ProjectInfo()
        {
            return View();
        }
        public ActionResult Events()
        {
            return View();
        }
        public ActionResult Volunteer()
        {
            return View();
        }
        public ActionResult Donations()
        {
            return View();
        }
        public ActionResult NewsInfo()
        {
            return View();
        }
    }
}