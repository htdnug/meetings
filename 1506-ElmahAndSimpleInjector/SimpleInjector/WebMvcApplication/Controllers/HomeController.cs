using System.Web.Mvc;
using ClassLibrary.Services;

namespace WebMvcApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var service = DependencyResolver.Current.GetService<IMyService>();
            var items = service.GetItems();
            return View(items);
        }
    }
}