using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Application.ViewModels.Account;
using Store_BootCamp.Domain.InterfacesRepository;

namespace Store_BootCamp.Web.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class HomeController : Controller
    {
        private readonly IUserService userRepository;
        public HomeController(IUserService user)
        {
            userRepository = user;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserList()
        {
            var list = userRepository.GetUsers();
            return View(list);
        }
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
            userRepository.saveChanges();
            return RedirectToAction("UserList");
        }
        [HttpGet]
        public IActionResult EditUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditUser(UserViewmodel userViewmodel)
        {
            return View();
        }
    }
}
