using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NMTLesson.Models;

namespace NMTLesson.Controllers
{
    public class NMTHomeController : Controller
    {
        private readonly ILogger<NMTHomeController> _logger;

        public NMTHomeController(ILogger<NMTHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NMTIndex()
        {
            return View();
        }

        public IActionResult NMTPrivacy()
        {
            return View();
        }

        public IActionResult NMTAbout()
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
