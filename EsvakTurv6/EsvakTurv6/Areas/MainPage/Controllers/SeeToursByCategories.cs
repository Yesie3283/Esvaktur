using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsvakTurv6.Areas.MainPage.Controllers
{
    // Class isminin sonuna Controller eklendi!
    public class SeeToursByCategoriesController : Controller
    {
        EsvakTurv6.Models.EsvakTur db = new EsvakTurv6.Models.EsvakTur();

        // GET: MainPage/SeeToursByCategories/Index/id
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "SeeCategories");
            }

            var category = db.TourCategories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryName = category.Name;

            var tours = db.Tours.Where(x => x.TourCategories_ID == id).ToList();

            return View(tours);
        }
    }
}