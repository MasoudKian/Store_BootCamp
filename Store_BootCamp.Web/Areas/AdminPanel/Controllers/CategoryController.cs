using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Services.Interfaces;

namespace Store_BootCamp.Web.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService category)
        {
            _categoryService = category;
        }


        public IActionResult Index()
        {

            return View(_categoryService.GetAllCategory());
        }
    }
}
