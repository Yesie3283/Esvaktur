using System;
using System.Linq;
using System.Web.Mvc;
using EsvakTurv6.Models;

namespace EsvakTurv6.Areas.MainPage.Controllers
{
    public class RegisterController : Controller
    {
        private EsvakTur db = new EsvakTur();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Bu e-posta adresi zaten kayıtlı.");
                    return View(user);
                }

                db.Users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Index", "MainPage");
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            var user = db.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);

            if (user != null)
            {
                Session["UserID"] = user.ID;
                Session["UserName"] = user.Name;
                return RedirectToAction("Index", "MainPage");
            }

            ModelState.AddModelError("", "Geçersiz e-posta veya şifre.");
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "MainPage");
        }
    }
}