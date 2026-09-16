using Microsoft.AspNetCore.Mvc;
using TvcLesson02Demo.Models;

namespace TvcLesson02Demo.Controllers
{
    public class TvcProductController : Controller
    {
        public IActionResult Index()
        {
            // Đưa dữ liệu ra view

            ViewBag.name = "Chung Trịnh";
            ViewData["address"] = "Fit NTU ";
            TempData["UNI"] = "Trường Đại Học Nguyễn Trãi";

            return View();
        }

        // chi tiết sản  phẩm
        public IActionResult GetProduct()
        {
            //Mock data
            TvcProduct tvcProduct = new TvcProduct()
            {
                ProductId="P001",
                ProductName="Laptop Dell Vostro",
                YearRelease=2024,
                Price=12000000,
            };

            ViewData["productVD"]=tvcProduct;
            ViewBag.productVB = tvcProduct;

            return View();
        }
    }
}
