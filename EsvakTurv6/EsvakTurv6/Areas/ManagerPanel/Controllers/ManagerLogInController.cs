using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; 
using EsvakTurv6.Models;

namespace EsvakTurv6.Areas.ManagerPanel.Controllers
{
    
    [AllowAnonymous]
    public class ManagerLogInController : Controller
    {
        EsvakTurv6.Models.EsvakTur db = new EsvakTurv6.Models.EsvakTur();

        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string NickName, string Password)
        {
            
            if (!string.IsNullOrEmpty(NickName) && !string.IsNullOrEmpty(Password))
            {
                
                var user = db.Managers.FirstOrDefault(u => u.NickName == NickName && u.Password == Password && u.IsActive);

                if (user != null)
                {
                    
                    FormsAuthentication.SetAuthCookie(user.NickName, false);

                    
                    return RedirectToAction("Index", "Dashboard", new { area = "ManagerPanel" });
                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz kullanıcı adı, şifre veya hesapsız aktif değil!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Lütfen tüm alanları doldurun.");
            }

            
            return View();
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); 
            Session.Abandon(); 
            return RedirectToAction("Index"); 
        }
    }
}