using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UtahCrashes.Models;

namespace UtahCrashes.Components
{
    public class CountyViewComponent : ViewComponent
    {
        private ICrashesRepository repo { get; set; }

        public CountyViewComponent (ICrashesRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCounty = RouteData?.Values["County_Name"];

            var counties = repo.Crashes
                .Select(x => x.County)
                .Distinct()
                .OrderBy(x => x);

            return View(counties);
        }

    }
}
