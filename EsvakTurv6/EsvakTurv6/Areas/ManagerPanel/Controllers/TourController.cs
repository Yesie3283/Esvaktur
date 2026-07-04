using EsvakTurv6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO; // DEĞİŞİKLİK: Dosya kaydetme (Path, Directory) işlemleri için eklendi.

namespace EsvakTurv6.Areas.ManagerPanel.Controllers
{
    [Authorize]
    public class TourController : Controller
    {
        EsvakTurv6.Models.EsvakTur db = new EsvakTurv6.Models.EsvakTur();

        public ActionResult Index()
        {
            var tours = db.Tours.Include(t => t.TourCategories).Where(t => !t.IsDeleted).ToList();
            return View(tours);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var tour = db.Tours.Find(id);
            if (tour != null)
            {
                
                tour.IsDeleted = true;
                db.SaveChanges();
            }

           
            string redirectUrl = Url.Action("Index", "Tour", new { area = "ManagerPanel" });
            return Content("<script>parent.location.href = '" + redirectUrl + "';</script>");
        }

        public ActionResult GetTours()
        {
            var values = db.Tours.Where(t => !t.IsDeleted).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TourCategories_ID = new SelectList(db.TourCategories.Where(c => c.IsActive), "ID", "Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tours tour, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                
                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    try
                    {
                       
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);

                        
                        string folderPath = Server.MapPath("~/images/tours/");

                        
                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        
                        string fullPath = Path.Combine(folderPath, fileName);

                        
                        ImageFile.SaveAs(fullPath);

                       
                        tour.ImagePath = "/images/tours/" + fileName;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Resim yüklenirken bir hata oluştu: " + ex.Message);
                        ViewBag.TourCategories_ID = new SelectList(db.TourCategories.Where(c => c.IsActive), "ID", "Name", tour.TourCategories_ID);
                        return View(tour);
                    }
                }
                else
                {
                    
                    ModelState.AddModelError("ImagePath", "Lütfen tur için bir resim seçin.");
                    ViewBag.TourCategories_ID = new SelectList(db.TourCategories.Where(c => c.IsActive), "ID", "Name", tour.TourCategories_ID);
                    return View(tour);
                }

                tour.IsDeleted = false; 

                db.Tours.Add(tour);
                db.SaveChanges();

                return RedirectToAction("Index", "Tour", new { area = "ManagerPanel" });
            }

            ViewBag.TourCategories_ID = new SelectList(db.TourCategories.Where(c => c.IsActive), "ID", "Name", tour.TourCategories_ID);
            return View(tour);
        }

        public ActionResult Edit(int id)
        {
            var tour = db.Tours.Find(id);
            if (tour == null || tour.IsDeleted)
            {
                return HttpNotFound();
            }

            ViewBag.TourCategories_ID = new SelectList(db.TourCategories.Where(c => c.IsActive), "ID", "Name", tour.TourCategories_ID);
            return View(tour);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tours tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Tour", new { area = "ManagerPanel" });
            }

            ViewBag.TourCategories_ID = new SelectList(db.TourCategories.Where(c => c.IsActive), "ID", "Name", tour.TourCategories_ID);
            return View(tour);
        }
    }
}