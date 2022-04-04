using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UtahCrashes.Models;

namespace UtahCrashes.Controllers
{
    public class HomeController : Controller
    {
        private ICrashesRepository repo { get; set; }
        private CrashesDbContext context { get; set; }

        public HomeController(ICrashesRepository temp)
        {
            repo = temp;
        }

        // landing page
        public IActionResult Index()
        {
            return View();
        }

        // displays all the crashes (with pagination and filtering by county)
        public IActionResult Summary()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCrash()
        {
            Crash crash = new Crash();

            ViewBag.Crashes = repo.Crashes.ToList();
            ViewBag.Counties = repo.Counties.ToList();

            return View(crash);
        }

        [HttpPost]
        public IActionResult AddCrash(Crash c)
        {
            if (ModelState.IsValid)
            {
                c.Crash_ID = (repo.Crashes.Max(c => c.Crash_ID)) + 1;
                repo.AddCrash(c);
                return RedirectToAction("Summary");
            }
            else
            {
                ViewBag.Crashes = repo.Crashes.ToList();
                ViewBag.Counties = repo.Counties.ToList();
                return View(c);
            }
        }

        [HttpGet]
        public IActionResult EditCrash(int crashid)
        {
            ViewBag.Counties = repo.Counties.ToList();

            var crash = repo.Crashes.Single(x => x.Crash_ID == crashid);

            return View("AddCrash", crash);
        }

        [HttpPost]
        public IActionResult EditCrash(Crash c)
        {
            repo.EditCrash(c);
            return RedirectToAction("Summary");
        }

        public IActionResult DeleteCrash(Crash c)
        {
            repo.DeleteCrash(c);
            return RedirectToAction("Summary");
        }

        // makes a prediction of crash severity based on featuers
        public IActionResult CrashCalc()
        {
            return View();
        }

<<<<<<< Updated upstream
        public IActionResult CrashMaps()
        {
            return View();
        }
        public IActionResult Privacy()
=======
        // ranks the features and how they contribute to crash severity
        public IActionResult CrashFeatures()
>>>>>>> Stashed changes
        {
            return View();
        }

        // GDPR
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
