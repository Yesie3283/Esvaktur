using System;
using System.Data.Entity; 
using System.Linq;
using System.Web.Mvc;
using EsvakTurv6.Models;

namespace EsvakTurv6.Areas.ManagerPanel.Controllers
{
    public class BookingsController : Controller
    {
        EsvakTur db = new EsvakTur();


        public ActionResult Index()
        {
     
            if (Session["ManagerID"] == null)
            {
                return RedirectToAction("Index", "ManagerLogIn");
            }

            
            var bookings = db.Bookings
                             .Include(b => b.User)
                             .Include(b => b.Tour)
                             .OrderByDescending(b => b.ID)
                             .ToList();

        
            ViewBag.TotalBookings = bookings.Count;
            ViewBag.UpcomingCount = bookings.Count(b => b.Tour != null && b.Tour.TourTime >= DateTime.Now);
            ViewBag.CompletedCount = bookings.Count(b => b.Tour != null && b.Tour.TourTime < DateTime.Now);

            return View(bookings);
        }

  
        public ActionResult Delete(int id)
        {
            if (Session["ManagerID"] == null)
            {
                return RedirectToAction("Index", "ManagerLogIn");
            }

            var booking = db.Bookings.Find(id);
            if (booking != null)
            {
                db.Bookings.Remove(booking);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Rezervasyon kaydı sistemden silindi.";
            }

            return RedirectToAction("Index");
        }
    }
}