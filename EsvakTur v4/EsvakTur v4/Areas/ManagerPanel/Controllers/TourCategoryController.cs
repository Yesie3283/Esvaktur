using EsvakTur_v4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsvakTur_v4.Areas.ManagerPanel.Controllers
{
    public class TourCategoryController : Controller
    {
        private EsvaTurV4Model db = new EsvaTurV4Model();
        // GET: ManagerPanel/TourCategory
        public ActionResult Index()
        {
            return View(db.TourCategories.ToList());
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(TourCategory tourCategory)
        {
            if (ModelState.IsValid)
            {
                db.TourCategories.Add(tourCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tourCategory);
        }
    }
}