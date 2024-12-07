using CharityConnect.Data;
using CharityConnect.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.Controllers
{
    public class DonationController : Controller
    {
        private Repository<Donation> Donations;

        public DonationController(ApplicationDbContext context)
        {
            Donations = new Repository<Donation>(context);
        }
        public async Task<IActionResult> Index()
        {
            return View(await Donations.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await Donations.GetByIdAsync(id, new QueryOptions<Donation>() { Includes = "CaseDonations.Case" }));
        }

        //Donation/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonationId, Name")] Donation Donation)
        {
            if (ModelState.IsValid)
            {
                await Donations.AddAsync(Donation);
                return RedirectToAction("Index");
            }
            return View(Donation);
        }

        //Donation/Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return View(await Donations.GetByIdAsync(id, new QueryOptions<Donation> { Includes = "CaseDonations.Case" }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Donation Donation)
        {
            await Donations.DeleteAsync(Donation.DonationId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await Donations.GetByIdAsync(id, new QueryOptions<Donation> { Includes = "CaseDonations.Case" }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Donation Donation)
        {
            if (ModelState.IsValid)
            {
                await Donations.UpdateAsync(Donation);
                return RedirectToAction("Index");
            }
            return View(Donation);
        }
    }
}
