using CharityConnect.Data;
using CharityConnect.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharityConnect.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private Repository<Menu> menus;

        public MenuViewComponent(ApplicationDbContext context)
        {
            menus = new Repository<Menu>(context);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Sử dụng biến instance menus (không trùng tên)
            var menuList = await menus.GetAllAsync();

            var filteredMenuList = menuList
               .Where(c => !c.Hide)
               .OrderBy(c => c.Order)
               .ToList();
            return View(filteredMenuList); // Truyền dữ liệu đến ViewComponent
        }

    }
}
