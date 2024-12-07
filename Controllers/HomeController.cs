using CharityConnect.Data;
using CharityConnect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CharityConnect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Repository<Case> cases;
        //private Repository<Category> categories;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            cases = new Repository<Case>(context);
            //categories = new Repository<Category>(context);
        }

        public async Task<IActionResult> Index()
        {
            var caseList = await cases.GetAllAsync();
            //ViewBag.Categories = await categories.GetAllAsync();
            var filteredCaseList = caseList
                .Where(c => !c.Hide)          
                .OrderBy(c => c.Order)      
                .ToList();
            return View(filteredCaseList);
        }

        [Route("ve-chung-toi")]
        public IActionResult About()
        {
            return View();
        }

        [Route("bai-viet")]
        public IActionResult Blog()
        {
            return View();
        }


        [Route("lien-he")]
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
