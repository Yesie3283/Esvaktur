using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EsvakTurv6.Models;

namespace EsvakTurv6.Areas.MainPage.Controllers
{
    public class ToursController : Controller
    {
        private EsvakTur db = new EsvakTur();

        [HttpGet]
        public ActionResult Search(string query)
        {
            var tours = db.Tours.Include(t => t.TourCategories).AsQueryable();

            if (!string.IsNullOrEmpty(query))
            {
                tours = tours.Where(t => t.Title.Contains(query) || t.Description.Contains(query));
            }

            ViewBag.SearchQuery = query;
            return View(tours.ToList());
        }

        [HttpGet]
        public ActionResult AllTours()
        {
            var tours = db.Tours.Include(t => t.TourCategories).ToList();
            return View(tours);
        }
    }
}