using CharityConnect.Data;
using CharityConnect.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.Controllers
{
    public class CategoryController : Controller
    {
        private Repository<Category> categories;
        public CategoryController(ApplicationDbContext context)
        {
            categories = new Repository<Category>(context);
        }
        public async Task<IActionResult> Index()
        {
            return View(await categories.GetAllAsync());
        }
    }
}
