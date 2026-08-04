using EsvakTurv6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsvakTurv6.Areas.ManagerPanel.Controllers
{
    [Authorize]
    public class TourCategoryController : Controller
    {
        EsvakTurv6.Models.EsvakTur db = new EsvakTurv6.Models.EsvakTur();
        // GET: ManagerPanel/TourCategory
        public ActionResult Index()
        {
            
            var categories = db.TourCategories.ToList();
            return View(categories);
        }

        public ActionResult GetTourCategories()
        {
            var values = db.TourCategories.ToList();
            return View(values);
        }

        public ActionResult Details(int id)
        {
            var category = db.TourCategories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category); 
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TourCategories category)
        {
            if (ModelState.IsValid)
            {
                
                db.TourCategories.Add(category);
                db.SaveChanges();

                
                return RedirectToAction("Index");
            }

            
            return View(category);
        }

        public ActionResult Edit(int ID)
        {
            var category = db.TourCategories.Find(ID);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TourCategories category) 
        {
            if (ModelState.IsValid)
            {
      
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

               
                return RedirectToAction("Index", "TourCategory", new { area = "ManagerPanel" });
            }


            return View(category);
        }

            [HttpPost]

    
        public ActionResult Delete(int id)
        {
            var category = db.TourCategories.Find(id);
            if (category != null)
            {
                db.TourCategories.Remove(category);
                db.SaveChanges();
            }

           
            return Content("<script>parent.location.reload();</script>");
        }
    }
}