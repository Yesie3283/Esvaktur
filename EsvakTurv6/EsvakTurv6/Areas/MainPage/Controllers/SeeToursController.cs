using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EsvakTurv6.Models;

namespace EsvakTurv6.Areas.MainPage.Controllers
{
    public class SeeToursController : Controller
    {
        EsvakTurv6.Models.EsvakTur db = new EsvakTurv6.Models.EsvakTur();

        public ActionResult Index(int? categoryId)
        {
     
            var categories = db.TourCategories.ToList();
            ViewBag.Categories = new SelectList(categories, "ID", "Name", categoryId);

       
            List<Tours> tours;

            if (categoryId.HasValue && categoryId.Value > 0)
            {

                tours = db.Tours.Where(x => x.TourCategories_ID == categoryId.Value).ToList();
            }
            else
            {

                tours = db.Tours.ToList();
            }

            return View(tours);
        }
    }
}