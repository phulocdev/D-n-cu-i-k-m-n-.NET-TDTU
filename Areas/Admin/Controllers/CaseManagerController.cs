using CharityConnect.Data;
using CharityConnect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class CaseManagerController : Controller
    {
        private Repository<Case> cases;
        //private Repository<Donation> donations;
        private Repository<Category> categories;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CaseManagerController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            cases = new Repository<Case>(context);
            //donations = new Repository<Donation>(context);
            categories = new Repository<Category>(context);
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = await categories.GetAllAsync();
            var caseList = await cases.GetAllAsync();
            return View(caseList);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            //ViewBag.Donations = await donations.GetAllAsync();
            ViewBag.Categories = await categories.GetAllAsync();
            if (id == 0)
            {
                ViewBag.Operation = "Thêm mới";
                return View(new Case());
            }
            else
            {
                //Case existCase = await cases.GetByIdAsync(id, new QueryOptions<Case>
                //{
                //    Includes = "CaseDonations.Donations, Category"
                //});
                Case existCase = await cases.GetByIdAsync(id, new QueryOptions<Case>{});
                ViewBag.Operation = "Cập nhật";
                return View(existCase);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(Case myCase, int catId)
        {
            ViewBag.Categories = await categories.GetAllAsync();
            if (ModelState.IsValid)
            {

                if (myCase.ImageFile != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + myCase.ImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await myCase.ImageFile.CopyToAsync(fileStream);
                    }
                    myCase.ImageUrl = uniqueFileName;
                }

                if (myCase.CaseId == 0)
                {

                    myCase.CategoryId = catId;

                    await cases.AddAsync(myCase);
                    return RedirectToAction("Index", "CaseManager");
                }
                else
                {
                    var existingCase = await cases.GetByIdAsync(myCase.CaseId, new QueryOptions<Case> { });

                    if (existingCase == null)
                    {
                        ModelState.AddModelError("", "Case not found.");
                        ViewBag.Categories = await categories.GetAllAsync();
                        return View(myCase);
                    }

                    existingCase.Title = myCase.Title;
                    existingCase.Description = myCase.Description;
                    existingCase.Location = myCase.Location;
                    existingCase.Hide = myCase.Hide;
                    existingCase.CategoryId = catId;
                    existingCase.Meta = myCase.Meta;
                    existingCase.Order = myCase.Order;


                    try
                    {
                        await cases.UpdateAsync(existingCase);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", $"Error: {ex.GetBaseException().Message}");
                        ViewBag.Categories = await categories.GetAllAsync();
                        return View(myCase);
                    }
                }
            }
            return RedirectToAction("Index", "CaseManager");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await cases.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Hoàn cảnh không tồn tại");
                return RedirectToAction("Index");
            }
        }
    }
}
