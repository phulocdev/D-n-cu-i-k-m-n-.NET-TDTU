using CharityConnect.Data;
using CharityConnect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class MenuManagerController : Controller
    {
        private Repository<Menu> menus;

        public MenuManagerController(ApplicationDbContext context)
        {
            menus = new Repository<Menu>(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await menus.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            if (id == 0)
            {
                ViewBag.Operation = "Thêm mới";
                return View(new Menu());
            }
            else
            {
                //Case existCase = await cases.GetByIdAsync(id, new QueryOptions<Case>
                //{
                //    Includes = "CaseDonations.Donations, Category"
                //});
                Menu existMenu = await menus.GetByIdAsync(id, new QueryOptions<Menu> { });
                ViewBag.Operation = "Cập nhật";
                return View(existMenu);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(Menu myMenu)
        {
            if (string.IsNullOrWhiteSpace(myMenu.Link))
            {
                myMenu.Link = ""; // Hoặc một giá trị mặc định khác nếu cần
            }

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {

                if (myMenu.MenuId == 0)
                {

                    await menus.AddAsync(myMenu);
                    return RedirectToAction("Index", "MenuManager");
                }
                else
                {
                    var existingMenu = await menus.GetByIdAsync(myMenu.MenuId, new QueryOptions<Menu> { });

                    if (existingMenu == null)
                    {
                        ModelState.AddModelError("", "Menu not found.");
                        ViewBag.Categories = await menus.GetAllAsync();
                        return View(myMenu);
                    }

                    existingMenu.Name = myMenu.Name;
                    existingMenu.Link = myMenu.Link;
                    existingMenu.Meta = myMenu.Meta;
                    existingMenu.Hide = myMenu.Hide;
                    existingMenu.Order = myMenu.Order;
                       
                    try
                    {
                        await menus.UpdateAsync(existingMenu);
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", $"Error: {ex.GetBaseException().Message}");
                        return View(myMenu);
                    }
                }
            }
            return RedirectToAction("Index", "MenuManager");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await menus.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Menu không tồn tại");
                return RedirectToAction("Index");
            }
        }
    }
}
