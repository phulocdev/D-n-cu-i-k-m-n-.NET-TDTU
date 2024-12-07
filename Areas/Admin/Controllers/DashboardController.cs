using CharityConnect.Data;
using CharityConnect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Repository<Case> _cases; // Đổi tên biến để rõ ràng

        public DashboardController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _cases = new Repository<Case>(context); // Đảm bảo khởi tạo đúng repository
        }

        public async Task<IActionResult> Index()
        {
            // Lấy tất cả người dùng
            var users = _userManager.Users.ToList();

            // Truyền danh sách người dùng vào ViewBag
            ViewBag.UserList = users;

            // Truyền số lượng người dùng vào ViewBag
            ViewBag.UserCount = users.Count();

            // Truyền số lượng Case vào ViewBag
            var casesList = await _cases.GetAllAsync(); // Lấy danh sách các trường hợp bất đồng bộ
            ViewBag.CaseCount = casesList.Count(); // Đếm số lượng các case

            return View();
        }
    }
}
