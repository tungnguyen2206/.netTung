using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NmtLesson15.Models;

namespace NmtLesson15.Controllers;

public class HomeController : Controller
{
    private const string DisplayNameKey = "Nmt.DisplayName";
    private const string CounterKey = "Nmt.Counter";
    private const string ThemeCookieName = "Nmt.Theme";

    public IActionResult Index()
    {
        var model = new StateDemoViewModel
        {
            DisplayName = HttpContext.Session.GetString(DisplayNameKey) ?? string.Empty,
            Counter = HttpContext.Session.GetInt32(CounterKey) ?? 0,
            Theme = Request.Cookies[ThemeCookieName] ?? "Chưa thiết lập"
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SaveName(string? displayName)
    {
        var normalizedName = displayName?.Trim();
        if (string.IsNullOrWhiteSpace(normalizedName) || normalizedName.Length > 60)
        {
            TempData["NmtNotice"] = "Tên phải có từ 1 đến 60 ký tự.";
            return RedirectToAction(nameof(Index));
        }

        HttpContext.Session.SetString(DisplayNameKey, normalizedName);
        TempData["NmtNotice"] = "Tên đã được lưu trong Session của trình duyệt này.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult IncrementCounter()
    {
        var counter = HttpContext.Session.GetInt32(CounterKey) ?? 0;
        if (counter < int.MaxValue)
        {
            counter++;
        }

        HttpContext.Session.SetInt32(CounterKey, counter);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SaveTheme(string? theme)
    {
        if (theme is not ("light" or "dark"))
        {
            TempData["NmtNotice"] = "Vui lòng chọn giao diện hợp lệ.";
            return RedirectToAction(nameof(Index));
        }

        Response.Cookies.Append(ThemeCookieName, theme, new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddDays(30),
            HttpOnly = true,
            IsEssential = true,
            SameSite = SameSiteMode.Lax,
            Secure = Request.IsHttps
        });

        TempData["NmtNotice"] = "Giao diện đã được lưu bằng Cookie trong 30 ngày.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SendFlashMessage(string? message)
    {
        var normalizedMessage = message?.Trim();
        if (string.IsNullOrWhiteSpace(normalizedMessage) || normalizedMessage.Length > 120)
        {
            TempData["NmtNotice"] = "Thông báo phải có từ 1 đến 120 ký tự.";
            return RedirectToAction(nameof(Index));
        }

        TempData["NmtNotice"] = normalizedMessage;
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ClearState()
    {
        HttpContext.Session.Clear();
        Response.Cookies.Delete(ThemeCookieName);
        TempData["NmtNotice"] = "Đã xóa dữ liệu Session và Cookie của ứng dụng.";
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
