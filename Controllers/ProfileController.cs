using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolomonsAdviceWebApp.Data;
using SolomonsAdviceWebApp.Models.Entities;
using SolomonsAdviceWebApp.Services;

namespace SolomonsAdviceWebApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        private readonly AdviceService _adviceService;
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(AdviceService adviceService, UserManager<IdentityUser> userManager)
        {
            _adviceService = adviceService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var favoriteAdvices = await _adviceService.GetFavoritesAsync(userId);
            return View(favoriteAdvices);
        }
    }
}
