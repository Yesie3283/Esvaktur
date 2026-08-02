using EsvakTurv6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsvakTurv6.Areas.MainPage.Controllers
{
    public class MainPageController : Controller
    {
        EsvakTurv6.Models.EsvakTur db = new EsvakTurv6.Models.EsvakTur();

      
        public ActionResult Index()
        {

            var tours = db.Tours.Where(t => !t.IsDeleted && t.IsActive)
                                .OrderByDescending(t => t.ID)
                                .ToList();

           
            ViewBag.FeaturedTours = db.Tours.Where(t => !t.IsDeleted && t.IsActive)
                                            .OrderBy(t => t.Price) 
                                            .Take(3)
                                            .ToList();

           
            ViewBag.TotalTours = db.Tours.Count(t => !t.IsDeleted && t.IsActive);
            ViewBag.TotalCategories = db.TourCategories.Count(); 
           

            return View(tours);
        }

        public ActionResult Details(int id)
        {
            var tour = db.Tours.FirstOrDefault(t => t.ID == id && !t.IsDeleted && t.IsActive);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }
        public ActionResult ContactInf()
        {
            return View();
        }
    }
}















































































































































//The soul becomes dyed with the colour of its thoughts.- Marcus Aurelius