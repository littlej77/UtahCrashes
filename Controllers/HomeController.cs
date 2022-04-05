using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UtahCrashes.Models;
using UtahCrashes.Models.ViewModels;

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
        public IActionResult Summary(string county, int pageNum =1)
        {
            int pageSize = 10;

            var x = new CrashesViewModel
            {
                Crashes = repo.Crashes
                .Where(c => c.County.County_Name == county || county == null)
                .OrderBy(c => c.Crash_ID)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumCrashes =
                        (county == null
                            ? repo.Crashes.Count()
                            : repo.Crashes.Where(x => x.County.County_Name == county).Count()),
                    CrashesPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
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
        public IActionResult CrashMaps()
        {
            return View();
        }

        // ranks the features and how they contribute to crash severity
        public IActionResult CrashFeatures()
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
