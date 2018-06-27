using Microsoft.AspNetCore.Mvc;

namespace ABPBase.Web.Controllers
{
    public class HomeController : ABPBaseControllerBase
    {
        public ActionResult Index()
        {
           // return RedirectToAction("Index", "Tasks");
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}