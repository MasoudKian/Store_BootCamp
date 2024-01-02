using Microsoft.AspNetCore.Mvc;

namespace Store_BootCamp.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        [Route("/UserPanel/Orders")]
        public IActionResult Index()
        {
            return View();
        }

        //[Route("/UserPanel/FavoritesList")]
        //public IActionResult FavoritesList()
        //{
        //    return View();
        //}
    }
}
