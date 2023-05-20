using Microsoft.AspNetCore.Mvc;
using SocialApp.Models.DbModel;

namespace SocialWebApp.Controllers
{
	public class AccountController : Controller
	{
        public AccountController()
        {
            
        }
        public IActionResult Index()
		{
			return View();
		}
	}
}
