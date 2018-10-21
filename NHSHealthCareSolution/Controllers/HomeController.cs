using System.Web.Mvc;

namespace NHSHealthCareSolution.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}