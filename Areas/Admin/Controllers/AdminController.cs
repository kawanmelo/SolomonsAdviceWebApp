using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolomonsAdviceWebApp.Areas.Identity.Constants;

namespace SolomonsAdviceWebApp.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = Roles.Admin)]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
