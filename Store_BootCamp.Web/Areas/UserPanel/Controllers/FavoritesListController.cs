using Microsoft.AspNetCore.Mvc;

namespace Store_BootCamp.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class FavoritesListController : Controller
    {
        [Route("/UserPanel/FavoritesList")]
        public IActionResult FavoritesList()
        {
            return View();
        }
    }
}
