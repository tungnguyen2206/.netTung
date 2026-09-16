using Microsoft.AspNetCore.Mvc;
using TvcLesson07Models.Models.DataModels;

namespace TvcLesson07Models.Controllers
{
    public class TvcMemberController : Controller
    {
        // Mock Data
        protected static List<TvcMember> _members = new List<TvcMember>
        {
             new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "chungtv",
                TvcPassword = "123456",
                TvcFullName = "Trịnh Văn Chung",
                TvcEmail = "chungtrinhj@example.com"
            },
            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "tranthibinh",
                TvcPassword = "123456",
                TvcFullName = "Trần Thị Bình",
                TvcEmail = "tranthibinh@example.com"
            },
            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "levancuong",
                TvcPassword = "123456",
                TvcFullName = "Lê Văn Cường",
                TvcEmail = "levancuong@example.com"
            },
            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "phamthiduyen",
                TvcPassword = "123456",
                TvcFullName = "Phạm Thị Duyên",
                TvcEmail = "phamthiduyen@example.com"
            },
            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "hoangminhduc",
                TvcPassword = "123456",
                TvcFullName = "Hoàng Minh Đức",
                TvcEmail = "hoangminhduc@example.com"
            }
        };

        public IActionResult Index()
        {
            return View(_members);
        }
        public IActionResult GetMember()
        {
            var member = new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcUserName = "chungtv",
                TvcPassword = "password123",
                TvcFullName = "Trịnh  Văn Chung",
                TvcEmail = "chungtrinhj@gmail.com"
            };
            //ViewBag.Member = member;
            return View(member);
        }

        // Đưa dữ liệu dạng List ra View
        public IActionResult GetMembers()
        {
            // Lấy từ mock data
            ViewBag.Members = _members;
            return View();

        }

        // GET: Create member
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create member
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TvcMember member)
        {
            if (ModelState.IsValid)
            {
                member.TvcMemberId = Guid.NewGuid().ToString();
                _members.Add(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }
    }
}
