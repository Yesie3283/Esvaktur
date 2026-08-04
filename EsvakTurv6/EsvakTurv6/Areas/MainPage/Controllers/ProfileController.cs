using System;
using System.Linq;
using System.Web.Mvc;
using EsvakTurv6.Models;

namespace EsvakTurv6.Areas.MainPage.Controllers
{
    public class ProfileController : Controller
    {
        EsvakTur db = new EsvakTur();

        // GET: MainPage/Profile
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Register", new { area = "" });
            }

            int userId = Convert.ToInt32(Session["UserID"]);
            var user = db.Users.Find(userId);

            if (user == null)
            {
                return HttpNotFound();
            }

 
            var userBookings = db.Bookings.Where(b => b.UserID == userId).ToList();

            ViewBag.UpcomingTours = userBookings
                .Where(b => b.Tour != null && b.Tour.TourTime >= DateTime.Now)
                .Select(b => b.Tour)
                .ToList();

       
            ViewBag.CompletedTours = userBookings
                .Where(b => b.Tour != null && b.Tour.TourTime < DateTime.Now)
                .Select(b => b.Tour)
                .ToList();

            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateProfile(string Name, string UserName, string Email, string PhoneNumber, string NewPassword)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("Login", "Register", new { area = "" });

            int userId = Convert.ToInt32(Session["UserID"]);
            var user = db.Users.Find(userId);

            if (user != null)
            {
                user.Name = Name;
                user.UserName = UserName;
                user.Email = Email;
                user.PhoneNumber = PhoneNumber;

                if (!string.IsNullOrEmpty(NewPassword))
                {
                    user.Password = NewPassword;
                }

                db.SaveChanges();
                Session["UserName"] = user.UserName;
                TempData["SuccessMessage"] = "Profil bilgileriniz başarıyla güncellendi!";
            }

            return RedirectToAction("Index");
        }
    }
}