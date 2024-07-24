using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SolomonsAdviceWebApp.Areas.Identity.Constants;

namespace SolomonsAdviceWebApp.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = Roles.Admin)]
    public class AdminUsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdminUsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users;
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityUser identityUser = await _userManager.FindByIdAsync(id);
            if(identityUser == null)
            {
                ViewBag.ErrorMessage = "User not found!";
                return View("NotFound");
            }
            else
            {
                IdentityResult identityResult = await _userManager.DeleteAsync(identityUser);
                if(identityResult.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach(var error in  identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return View(nameof(Index));
            }
        }
    }
}
