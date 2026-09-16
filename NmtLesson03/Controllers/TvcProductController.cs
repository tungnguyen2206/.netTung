using Microsoft.AspNetCore.Mvc;
using TvcLesson03.Models;

namespace TvcLesson03.Controllers
{
    public class TvcProductController : Controller
    {
        // Tạo mock data
        private readonly List<TvcProduct> _products = new()
        {
            new TvcProduct
            {
                TvcProductId = "PROD-001",
                TvcProductName = "CPU Intel Core i9-14900K",
                TvcYearRelease = "2023",
                TvcPrice = 589.99m
            },
            new TvcProduct
            {
                TvcProductId = "PROD-002",
                TvcProductName = "CPU AMD Ryzen 7 7800X3D",
                TvcYearRelease = "2023",
                TvcPrice = 449.00m
            },
            new TvcProduct
            {
                TvcProductId = "PROD-003",
                TvcProductName = "VGA NVIDIA GeForce RTX 4090 24GB",
                TvcYearRelease = "2022",
                TvcPrice = 1599.99m
            },
            new TvcProduct
            {
                TvcProductId = "PROD-004",
                TvcProductName = "VGA ASUS ROG Strix GeForce RTX 4070 Ti Super",
                TvcYearRelease = "2024",
                TvcPrice = 849.50m
            },
            new TvcProduct
            {
                TvcProductId = "PROD-005",
                TvcProductName = "Mainboard ASUS ROG MAXIMUS Z790 HERO",
                TvcYearRelease = "2022",
                TvcPrice = 629.99m
            },
            new TvcProduct
            {
                TvcProductId = "PROD-006",
                TvcProductName = "RAM Corsair Dominator Titanium RGB 64GB DDR5 6000MHz",
                TvcYearRelease = "2023",
                TvcPrice = 314.99m
            },
            new TvcProduct
            {
                TvcProductId = "PROD-007",
                TvcProductName = "SSD Samsung 990 PRO 2TB PCIe 4.0 NVMe",
                TvcYearRelease = "2022",
                TvcPrice = 189.99m
            },
            new TvcProduct
            {
                TvcProductId = "PROD-008",
                TvcProductName = "Nguồn Seasonic Prime TX-1000 1000W Titanium",
                TvcYearRelease = "2021",
                TvcPrice = 299.00m
            },
            new TvcProduct
            {
                TvcProductId = "PROD-009",
                TvcProductName = "Màn hình Dell UltraSharp U2724D 27 inch 2K IPS",
                TvcYearRelease = "2023",
                TvcPrice = 479.00m
            },
            new TvcProduct
            {
                TvcProductId = "PROD-010",
                TvcProductName = "Laptop Apple MacBook Pro 16 inch M3 Max",
                TvcYearRelease = "2023",
                TvcPrice = 3499.00m
            }
        };
        public IActionResult Index()
        {
            return Json(_products);
        }

        // GET: danh sách sản phẩm
        public IActionResult TvcGetAllProduct()
        {
            ViewData["products"] = _products;
            return View();
        }

        public IActionResult TvcGetListProduct()
        {
            return View(_products);
        }
    }
}
