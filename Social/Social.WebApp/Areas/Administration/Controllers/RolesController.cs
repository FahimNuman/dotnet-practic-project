using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Social.Common.Utilities;
using Social.Models.DbModels;
using Social.Repositories.Administration.Interfaces;
using Social.WebApp.Utilities;
using System.Collections.Generic;

namespace Social.WebApp.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = "Super Admin,Admin")]
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


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DbRole model = await _roleRepo.GetRoleByIdAsync(id.Value);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DbRole? model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    model.UpdatedBy = 1;
                    bool role = await _roleRepo.UpdateRoleAsync(model);
                    if (role)
                    {
                        DisplayMessageHelper.GetOrSetSuccessMeesage(this, true, ConstantMessages.DateUpdateSuccess);
                        return RedirectToAction(nameof(Index), new { area = "Administration" });
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

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DbRole model = await _roleRepo.GetRoleByIdAsync(id.Value);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                DbRole model = await _roleRepo.GetRoleByIdAsync(id);
                if (model == null)
                {
                    return NotFound();
                }

                bool roleDeleted = await _roleRepo.DeleteRoleAsync(model);
                if (roleDeleted)
                {
                    DisplayMessageHelper.GetOrSetSuccessMeesage(this, true, ConstantMessages.DataDeleteSuccess);
                    return RedirectToAction(nameof(Index), new { area = "Administration" });
                }
                else
                {
                    DisplayMessageHelper.GetOrSetErrorMeesage(this, true, ConstantMessages.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                DisplayMessageHelper.GetOrSetErrorMeesage(this, true, ex.Message);
            }

            return View();
        }
    }

    
}
