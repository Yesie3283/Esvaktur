using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsvakTurv6.Areas.ManagerPanel.Controllers
{
    public class DashboardController : Controller
    {
        EsvakTurv6.Models.EsvakTur db = new EsvakTurv6.Models.EsvakTur();

        [Authorize]
        public ActionResult Index()
        {
            
            ViewBag.TotalTours = db.Tours.Count(t => !t.IsDeleted);
            ViewBag.ActiveTours = db.Tours.Count(t => !t.IsDeleted && t.IsActive);
            ViewBag.TotalCategories = db.TourCategories.Count(c => c.IsActive);

            
            var categoryData = db.Tours
                .Where(t => !t.IsDeleted)
                .GroupBy(t => t.TourCategories.Name) 
                .Select(g => new
                {
                    CategoryName = g.Key,
                    TourCount = g.Count()
                }).ToList();

            
            ViewBag.ChartLabels = categoryData.Select(x => x.CategoryName).ToArray();
            ViewBag.ChartValues = categoryData.Select(x => x.TourCount).ToArray();

            return View();
        }
    }
}