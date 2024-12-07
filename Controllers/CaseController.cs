using CharityConnect.Data;
using CharityConnect.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.Controllers
{
    [Route("hoan-canh")]
    public class CaseController : Controller
    {
        private Repository<Case> cases;
        private Repository<Category> categories;

        public CaseController(ApplicationDbContext context)
        {
            cases = new Repository<Case>(context);
            categories = new Repository<Category>(context);
        }

        public async Task<IActionResult> Index()
        {
            var caseList = await cases.GetAllAsync();
            //!c.Hide ~ not hide 
            var filteredCaseList = caseList
                .Where(c => !c.Hide)
                .OrderBy(c => c.Order)
                .ToList();

            return View(filteredCaseList);
        }

        [Route("{meta}-{id:int}")]
        public async Task<IActionResult> Details(int id, string meta) {
            ViewBag.Categories = await categories.GetAllAsync();
            return View(await cases.GetByIdAsync(id, new QueryOptions<Case>() {}));
        }
    }
}
