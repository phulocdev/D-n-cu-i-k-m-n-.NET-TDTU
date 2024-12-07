using CharityConnect.Data;
using CharityConnect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
