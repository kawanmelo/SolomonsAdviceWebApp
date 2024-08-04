using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SolomonsAdviceWebApp.Data;
using SolomonsAdviceWebApp.Models;
using SolomonsAdviceWebApp.Models.Entities;
using SolomonsAdviceWebApp.Services;

namespace SolomonsAdviceWebApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        private readonly AdviceService _adviceService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ProfileController(AdviceService adviceService, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _adviceService = adviceService;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var favoriteAdvices = await _adviceService.GetFavoritesAsync(userId);
            return View(favoriteAdvices);
        }


        [HttpPost]
        public async Task<IActionResult> AddToFav(int id)
        {
            string urlAnterior = Request.Headers["Referer"].ToString();
            var userId = _userManager.GetUserId(User);
            var existingFavorite = await _context.FavoriteAdvices
                .FirstOrDefaultAsync(fav => fav.AdviceId == id && fav.UserId == userId);

            if (existingFavorite != null)
            {
                return Redirect(urlAnterior);
            }

            var favoriteAdvice = new FavoriteAdvice
            {
                Id = Guid.NewGuid().ToString(),
                AdviceId = id,
                UserId = userId
            };

            _context.FavoriteAdvices.Add(favoriteAdvice);
            await _context.SaveChangesAsync();

            return Redirect(urlAnterior);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveToFav(int id)
        {
            string urlAnterior = Request.Headers["Referer"].ToString();
            var existingFavorite = await _context.FavoriteAdvices.Where(x => x.AdviceId == id).FirstOrDefaultAsync();
            if(existingFavorite != null)
            {
                _context.FavoriteAdvices.Remove(existingFavorite);
                await _context.SaveChangesAsync();
            }
            return Redirect(urlAnterior);
        }
    }
}
