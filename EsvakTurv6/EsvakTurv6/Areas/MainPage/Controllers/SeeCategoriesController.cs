using EsvakTurv6.Models;
using System.Linq;
using System.Web.Mvc;

namespace EsvakTurv6.Areas.MainPage.Controllers
{
    public class SeeCategoriesController : Controller
    {
        private EsvakTur db = new EsvakTur();

        // GET: MainPage/SeeCategories
        public ActionResult Index()
        {
            var categories = db.TourCategories.ToList();
            return View(categories);
        }
    }
}