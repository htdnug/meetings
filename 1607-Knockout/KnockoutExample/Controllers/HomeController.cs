using System.Web.Mvc;

namespace KnockoutExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Knockout()
        {
            ViewBag.Message = "A Knockout example page.";
            return View();
        }
    }
}