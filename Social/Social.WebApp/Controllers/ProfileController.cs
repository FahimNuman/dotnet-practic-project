using Microsoft.AspNetCore.Mvc;

namespace Social.WebApp.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
