using System.Web.Mvc;

namespace EmployeesWeb.Controllers
{
    /// <summary>
    /// Main page controller
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}