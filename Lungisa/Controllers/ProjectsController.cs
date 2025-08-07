using Lungisa.Models;
using Lungisa.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Lungisa.Controllers
{
    public class ProjectsController : Controller
    {
        FirebaseService firebase = new FirebaseService();


        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var projects = await firebase.GetAllProjectsWithKeys() ?? new List<Lungisa.Models.FirebaseProject>();
            ViewBag.Success = TempData["Success"];
            return View("~/Views/Admin/ProjectInfo.cshtml", projects);
        }



        [HttpGet]
        public async Task<ActionResult> ProjectInfo()
        {
            var Projects = await firebase.GetAllProjectsWithKeys();
            ViewBag.Success = TempData["Success"];
            return View("~/Views/Admin/ProjectInfo.cshtml", Projects);
        }

        [HttpPost]
        public async Task<ActionResult> AddProject(string title, string type, string description, string startDate, string endDate)
        {
            ProjectModel Project = new ProjectModel
            {
                Title = title,
                Type = type,
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                ImageUrl = "/Content/default.png"
            };

            await firebase.SaveProject(Project);
            TempData["Success"] = "✅ Project was added successfully!";
            return RedirectToAction("ProjectInfo");
        }

        public async Task<ActionResult> Delete(string id)
        {
            await firebase.DeleteProject(id);
            TempData["Success"] = "🗑️ Project deleted successfully!";
            return RedirectToAction("ProjectInfo");
        }
    }
}
