using Microsoft.AspNetCore.Mvc;
using NMTLesson.Models;

namespace NMTLesson.Controllers
{
    public class NMTMemberController : Controller
    {
        // Mock data - NMTMember
        private static List<NMTMember> _members = new List<NMTMember>()
        {
            new NMTMember
            {
                NMTMemberId = Guid.NewGuid().ToString(),
                NMTUserName = "ChungTv",
                NMTPassword = "Password123!",
                NMTFullName = "Trịnh Văn Chung",
                NMTEmail = "chungtrinhj@gmail.com"
            },
            new NMTMember
            {
                NMTMemberId = Guid.NewGuid().ToString(),
                NMTUserName = "tranthib",
                NMTPassword = "SecurePass456#",
                NMTFullName = "Trần Thị B",
                NMTEmail = "tranthib@outlook.com"
            },
            new NMTMember
            {
                NMTMemberId = Guid.NewGuid().ToString(),
                NMTUserName = "levanc",
                NMTPassword = "MyPassword789$",
                NMTFullName = "Lê Văn C",
                NMTEmail = "levanc@company.com"
            }
        };

        // GET: Danh sách thành viên
        public IActionResult Index()
        {
            return View(_members);
        }

        [HttpGet]
        public IActionResult NMTCreate()
        {
            var member = new NMTMember();
            return View(member);
        }
        [HttpPost]
        public IActionResult NMTCreate(NMTMember nmtMember)
        {
            nmtMember.NMTMemberId = Guid.NewGuid().ToString();
            _members.Add(nmtMember);

            return RedirectToAction("Index");
            //return View(nmtMember);
        }

        [HttpGet]
        public IActionResult NMTEdit(string id)
        {
            var member = _members.Where(x=>x.NMTMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpPost]
        public IActionResult NMTEdit(string id, NMTMember nmtMember)
        {
            // var member = _members.Where(x => x.NMTMemberId.Equals(id)).FirstOrDefault();
            for (int i = 0; i < _members.Count; i++)
            {
                if (_members[i].NMTMemberId == id)
                {
                    _members[i].NMTUserName = nmtMember.NMTUserName;
                    _members[i].NMTPassword = nmtMember.NMTPassword;
                    _members[i].NMTFullName= nmtMember.NMTFullName;
                    _members[i].NMTEmail=   nmtMember.NMTEmail;

                    return RedirectToAction("Index");
                }
           
            }
            return View();
        }

        [HttpGet]
        public IActionResult NMTDetails(string id)
        {
            var member = _members.Where(x => x.NMTMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpGet]
        public IActionResult NMTDelete(string id)
        {
            var member = _members.Where(x => x.NMTMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }

        [HttpPost]
        public IActionResult NMTDeleted(string id)
        {
            foreach (var item in _members)
            {
                if (item.NMTMemberId.Equals(id))
                {
                    _members.Remove(item);
                    return RedirectToAction("Index");
                }
            }
            return View("NMTDelete");
        }
    }
}
