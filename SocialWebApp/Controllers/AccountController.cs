using Microsoft.AspNetCore.Mvc;
using Social.Common.Utilities;
using SocialApp.Models.DbModel;
using SocialWebApp.Utilities;

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

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(DbUser model)
		{
			
			if (ModelState.IsValid)
			{

			}
			else
			{
				DisplayMessageHelper.GetOrSetErrorMeesage(this, true, ConstantMessages.InvalidModelState);
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
