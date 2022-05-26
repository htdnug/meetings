using System;
using System.Web.Mvc;

namespace ElmahWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            throw new Exception("ELMAH Testing Exception");
            return View();
        }
    }
}