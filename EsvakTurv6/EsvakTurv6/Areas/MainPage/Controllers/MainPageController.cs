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
        // GET: MainPage/MainPage
        public ActionResult Index()
        {
            var tours = db.Tours.Where(t => !t.IsDeleted && t.IsActive).ToList();

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
    }
}