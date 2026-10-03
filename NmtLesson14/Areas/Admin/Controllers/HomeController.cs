using Microsoft.AspNetCore.Mvc;

namespace NMT.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
