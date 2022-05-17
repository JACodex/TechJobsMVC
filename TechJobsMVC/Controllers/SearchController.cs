using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Models;
using TechJobsMVC.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        static List<Job> jobs = new List<Job>();

        public IActionResult Index()
        {
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. ✅
        [HttpPost("/search/results")]
        public IActionResult Results(string searchType, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                jobs = JobData.FindAll();
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices;
            return Redirect("index");

        }
    }
}
