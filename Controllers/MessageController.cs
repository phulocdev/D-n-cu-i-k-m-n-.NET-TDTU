using CharityConnect.Data;
using CharityConnect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.Controllers
{
    [Authorize()]
    [Route("tu-van")]
    public class MessageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public MessageController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            // Lấy thông tin người dùng hiện tại
            var user = await _userManager.GetUserAsync(User);
            string userEmail = user?.Email ?? "Unknown";

            // Truyền email xuống View
            ViewBag.UserEmail = userEmail;
            return View();
        }
    }
}
