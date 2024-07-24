using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SolomonsAdviceWebApp.Areas.Admin.Models;
using SolomonsAdviceWebApp.Areas.Identity.Constants;
using System.ComponentModel.DataAnnotations;

namespace SolomonsAdviceWebApp.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = Roles.Admin)]
    public class AdminRolesController : Controller
    {
       private readonly RoleManager<IdentityRole> _roleManager;
       private readonly UserManager<IdentityUser> _userManager;

        public AdminRolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public ActionResult Index() { return View(_roleManager.Roles); }

        public IActionResult Create() { return View(); }

        [HttpPost]
        public async Task<ActionResult> Create([Required] string name)
        {
            if(ModelState.IsValid)
            {
                IdentityResult identityResult = await _roleManager.CreateAsync(new IdentityRole(name));
                if(identityResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    Errors(identityResult);
                }
            }
            return View(name);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            IdentityRole identityRole = await _roleManager.FindByIdAsync(id);

            List<IdentityUser> members = new List<IdentityUser>();
            List<IdentityUser> nomMembers = new List<IdentityUser>();

            foreach(var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, identityRole.Name) ? members : nomMembers;
                list.Add(user);
            }

            return View(new RoleEdit
            {
                Role = identityRole,
                Members = members,
                NonMembers = nomMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult identityResult;

            if(ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[]{} )
                {
                    IdentityUser identityUser = await _userManager.FindByIdAsync(userId);
                    if (identityUser != null)
                    {
                        identityResult = await _userManager.AddToRoleAsync(identityUser, model.RoleName);
                        if(!identityResult.Succeeded)
                        {
                            Errors(identityResult);
                        }
                    }
                }

                foreach(string userId in model.DeleteIds ?? new string[]{} )
                {
                    IdentityUser identityUser = await _userManager.FindByIdAsync(userId);
                    if(identityUser != null)
                    {
                        identityResult = await _userManager.RemoveFromRoleAsync(identityUser, model.RoleName);
                        if (!identityResult.Succeeded)
                        {
                            Errors(identityResult);
                        }
                    }
                }
            }
            if(ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return await Update(model.RoleId);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole identityRole = await _roleManager.FindByIdAsync(id);
            if (identityRole == null)
            {
                ModelState.AddModelError("", "Role not found");
            }
            return View(identityRole);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfrimed(string id)
        {
            IdentityRole identityRole = await _roleManager.FindByIdAsync(id);

            if (identityRole != null)
            {
                IdentityResult identityResult = await _roleManager.DeleteAsync(identityRole);
                if(identityResult.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Errors(identityResult);
                }
            }
            else
            {
                ModelState.AddModelError("", "Role not found");
            }
            return View(nameof(Index), _roleManager.Roles);
        }

        private void Errors(IdentityResult result)
        {
            foreach(IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
