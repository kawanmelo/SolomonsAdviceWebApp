using Microsoft.AspNetCore.Mvc;
using SolomonsAdviceWebApp.Data;
using SolomonsAdviceWebApp.Models;
using SolomonsAdviceWebApp.Services;
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
            var randomAdvice = await _adviceService.GetRandomAsync();
            ViewBag.RandomAdvice = randomAdvice;
            return View();
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
