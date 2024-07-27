using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolomonsAdviceWebApp.Data;
using SolomonsAdviceWebApp.Models;
using SolomonsAdviceWebApp.Models.Entities;
using SolomonsAdviceWebApp.Services;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SolomonsAdviceWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AdviceService _adviceService;


        public HomeController(ILogger<HomeController> logger, AdviceService adviceService)
        {
            _logger = logger;
            _adviceService = adviceService;
        }

        public async Task<IActionResult> Index()
        {
            if (DailyAdviceCache.DailyAdvice == null)
            {
                DailyAdviceCache.DailyAdvice = await _adviceService.GetRandomAsync();
            }

            var advice = DailyAdviceCache.DailyAdvice;
            return View(advice);

        }

        public async Task<IActionResult> RandomAdvice()
        {
            var randomAdvice = await _adviceService.GetRandomAsync();
            return View(randomAdvice);
        }

        [Authorize]
        public IActionResult AdviceByWord()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AdviceOnCard(string text)
        {

            if(!String.IsNullOrEmpty(text))
            {
                var adviceList = await _adviceService.GetByTextAsync(text);
                return View(adviceList);
            }
            return View("AdviceByWord");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
