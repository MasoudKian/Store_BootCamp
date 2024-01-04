using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Generators;
using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Application.ViewModels.Account;
using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Account;

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
        public IActionResult DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
            userRepository.saveChanges();
            return RedirectToAction("UserList");
        }
        public IActionResult FullDeleteUser(int id)
        {
            userRepository.FullDeleteUser(id);
            userRepository.saveChanges();
            return RedirectToAction("UserList");
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var user = userRepository.GetById(id);
            var userViewModel = new UserViewmodel();
            userViewModel.email = user.Email;
            userViewModel.isActive = user.IsActive;
            userViewModel.username = user.UserName;
            userViewModel.fullname = user.Fullname;
            userViewModel.img = user.UserImage;
            userViewModel.isAdmin = user.IsAdmin;


            return View(userViewModel);
        }
        [HttpPost]
        public IActionResult EditUser(UserViewmodel user)
        {
            var EditedUser = userRepository.GetById(user.id);
            EditedUser.Email = user.email;
            EditedUser.IsActive = user.isActive;
            EditedUser.UserImage = user.img;
            EditedUser.Fullname = user.fullname;
            EditedUser.UserName = user.username;
            EditedUser.IsAdmin = user.isAdmin;

            userRepository.UpdateUser(EditedUser);
            userRepository.saveChanges();
            return RedirectToAction("UserList");
        }
        [HttpGet]
        public IActionResult AddUserByAdmin()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddUserByAdmin(UserViewmodel userViewmodel)
        {
            var user = new User();

            if (userRepository.IsExistEmail(userViewmodel.email)==true)
            {
                return NotFound();
            }
            if (userViewmodel.img == null)
            {
                user.UserImage = "Defualt.png";
            }
            else
            {
                user.UserImage = userViewmodel.img;
            }
            if (userViewmodel != null )
            {
             

                user.Email = userViewmodel.email;
                user.Fullname = userViewmodel.fullname;
                user.UserName = userViewmodel.username;
                user.Password = userViewmodel.password;
                user.ActiveEmailCode = NameGenerator.GenerateUniqEmailCode();
                userRepository.RegisterUser(user);
                userRepository.saveChanges();
                return RedirectToAction("UserList");

            }


            return View();
        }
    }
}
