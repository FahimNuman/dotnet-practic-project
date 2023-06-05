using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Social.Common.Utilities;
using Social.Models.DbModels;
using Social.Models.VwModel;
using Social.Repositories.Administration.Interfaces;
using Social.WebApp.Utilities;
using System.Security.Claims;

namespace Social.WebApp.Controllers
{
    public class AccountsController : Controller
    {

        private readonly IUserRepo _userRepo;
        public AccountsController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Registration()
        {
            return View("~/Views/Accounts/Index.cshtml");
        }

        public IActionResult Login()
        {
            return View("~/Views/Accounts/Index.cshtml");
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Accounts");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(DbUser model)
        {
            model.RoleId = 5;

            if(ModelState.IsValid)
            {

               VwUser? user =  await _userRepo.SaveUserAsync(model);
                if(user == null)
                {
                    DisplayMessageHelper.GetOrSetErrorMeesage(this, true, ConstantMessages.ErrorMessage);
                    return View("~/Views/Accounts/Index.cshtml", model);
                }

                await SignInToApplicationAsync(user);
                return RedirectToAction("", "Home");
            }

            return View("~/Views/Accounts/Index.cshtml",model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            VwUser? user = await _userRepo.GetAuthorizedUserAsync(email, password);
            
            if(user == null )
            {
                DisplayMessageHelper.GetOrSetErrorMeesage(this, true, ConstantMessages.InvalidCredential);
                return View("~/Views/Accounts/Index.cshtml");
            }

            await SignInToApplicationAsync(user);

            if(user.RoleId == 5)
            {
                return RedirectToAction("", "Home");
            }

            return RedirectToAction("Index", "Roles", new { area = "Administration" });
        }

        #region Private Method

        private async Task<bool> SignInToApplicationAsync(VwUser user)
        {
            var clims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Email),
                    new Claim(ClaimTypes.Authentication, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, user.Name),
                };

            var climIdentity = new ClaimsIdentity(clims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(climIdentity), authProperties);
            return true;
        }


        #endregion
    }
}
