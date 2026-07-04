using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EsvakTur_v4.Models;

namespace EsvakTur_v4.Areas.ManagerPanel.Controllers
{
    public class DashboardController : Controller
    {
        private EsvaTurV4Model db = new EsvaTurV4Model();
        public ActionResult Index()
        {
            return View();
        }
    }
}