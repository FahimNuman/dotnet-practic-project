using Microsoft.AspNetCore.Mvc;
using Social.Common.Utilities;
using Social.Models.DbModels;
using Social.Repositories.Administration.Interfaces;
using Social.WebApp.Utilities;
using System.Collections.Generic;

namespace Social.WebApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class RolesController : Controller
    {
        private readonly IRoleRepo _roleRepo;

        public RolesController(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<DbRole> roles = await _roleRepo.GetAllRolesAsync();
            return View(roles);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(DbRole model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedBy = 1;
                    int result = await _roleRepo.SaveRoleAsync(model);
                    if (result > 0)
                    {
                        DisplayMessageHelper.GetOrSetSuccessMeesage(this, true, ConstantMessages.DateSaveSuccess);
                        return RedirectToAction(nameof(Index), "Roles", new { area = "Administration" });

                    }
                    else
                    {
                        DisplayMessageHelper.GetOrSetErrorMeesage(this, true, ConstantMessages.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayMessageHelper.GetOrSetErrorMeesage(this, true, ex.Message);
            }
            return View(model);
        }
    }
}
