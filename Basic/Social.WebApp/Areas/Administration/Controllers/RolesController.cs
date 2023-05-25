using Microsoft.AspNetCore.Mvc;

namespace Social.WebApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class RolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
