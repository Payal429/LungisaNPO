using Lungisa.Models;
using Lungisa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lungisa.Controllers
{
    public class EventsController : Controller
    {
        FirebaseService firebase = new FirebaseService();

        //GET: /Events
        public async Task<ActionResult> Index()
        {
            var events = await firebase.GetAllEventsWithKeys() ?? new List<Lungisa.Services.FirebaseService.FirebaseEvent>();
            ViewBag.Success = TempData["Success"];
            return View("~/Views/Admin/Events.cshtml", events);
        }

        [HttpGet]
        public async Task<ActionResult> EventsPage()
        {
            var events = await firebase.GetAllEventsWithKeys();
            ViewBag.Success = TempData["Success"];
            return View("~/Views/Admin/Events.cshtml", events);
        }

        [HttpPost]
        public async Task<ActionResult> AddEvent(string name, string dateTime, string venue, string description)
        {
            EventModel newEvent = new EventModel
            {
                Name = name,
                DateTime = dateTime,
                Venue = venue,
                Description = description
            };

            await firebase.SaveEvent(newEvent);
            TempData["Success"] = "✅ Event added successfully!";
            return RedirectToAction("EventsPage");
        }

        public async Task<ActionResult> Delete(string id)
        {
            await firebase.DeleteEvent(id);
            TempData["Success"] = "🗑️ Event deleted successfully!";
            return RedirectToAction("EventsPage");
        }
    }
}