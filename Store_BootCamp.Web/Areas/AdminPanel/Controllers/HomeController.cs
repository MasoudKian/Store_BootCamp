using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using Store_BootCamp.Application.Generators;
using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Application.ViewModels.Account;
using Store_BootCamp.Application.ViewModels.Ticket;
using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Account;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace Store_BootCamp.Web.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class HomeController : Controller
    {

        private IHostingEnvironment _environment;
        private readonly IUserService userRepository;
        private readonly ITicketService ticketService;
        public HomeController(IUserService user, ITicketService ticket, IHostingEnvironment environment)
        {
            userRepository = user;
            ticketService = ticket;
            _environment = environment;

        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllTickets()
        {
            var tickets = ticketService.GetAll();
            return View(tickets);
        }

        [HttpGet]
        public IActionResult TicketDetails(int id)
        {
            var ticketDetails = ticketService.GetTicketDetails(id);
            return View(ticketDetails);
        }
        [HttpPost]
        public IActionResult TicketDetails(TicketDetailsViewModel ticket)
        {

            var userId = User.Claims.FirstOrDefault().Value;
            if (ticket.ticketId !=null & ticket.massage !=null)
            {
            ticket.SenderId=int.Parse(userId);
            ticketService.AddTicketMassage(ticket);
         
            }

            return RedirectToAction("TicketDetails",ticket.ticketId);

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
            var user = userRepository.GetUserById(id);

            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(UserViewmodel user, IFormFile ImgUp)
        {
            #region UploadImg

            if (ImgUp != null)
            {
                user.img = Guid.NewGuid() + Path.GetExtension(ImgUp.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", user.img);
                using (var stram = new FileStream(imagePath, FileMode.Create))
                {
                    ImgUp.CopyTo(stram);
                }
            }



            #endregion


            userRepository.EditUser(user);
            userRepository.saveChanges();
            return RedirectToAction("UserList");
        }
        [HttpGet]
        public IActionResult AddUserByAdmin()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddUserByAdmin(UserViewmodel userViewmodel, IFormFile ImgUp)
        {
            #region uploadImg

            if (ImgUp != null)
            {
                userViewmodel.img = Guid.NewGuid() + Path.GetExtension(ImgUp.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", userViewmodel.img);
                using (var stram = new FileStream(imagePath, FileMode.Create))
                {
                    ImgUp.CopyTo(stram);
                }
            }


            #endregion

            var user = new User();

            if (userRepository.IsExistEmail(userViewmodel.email) == true)
            {
                return NotFound();
            }
            if (userViewmodel != null)
            {
                user.Email = userViewmodel.email;
                user.Fullname = userViewmodel.fullname;
                user.UserName = userViewmodel.username;
                user.Password = userViewmodel.password;
                user.ActiveEmailCode = NameGenerator.GenerateUniqEmailCode();
                user.UserImage = userViewmodel.img;
                userRepository.RegisterUser(user);
                userRepository.saveChanges();
                return RedirectToAction("UserList");

            }


            return View();
        }
        public IActionResult ChangeState(int id)
        {

            if (id != null) { ticketService.ChangeState(id); ticketService.SaveChange(); }
            return RedirectToAction("AllTickets");
        }
        [HttpGet]
        public IActionResult CreateMassageByAdmin(int id)
        {
            var user = userRepository.GetById(id);
            TempData["User"] = user.Email;
            TempData["UserId"] = user.Id;

            return View();
        }
        [HttpPost]
        public IActionResult CreateMassageByAdmin(AddTicketByAdminViewmodel ticketView)
        {
            var user = User.Claims.FirstOrDefault().Value;
            if (ModelState.IsValid)
            {
                ticketService.CreateTickAdmin(ticketView, int.Parse(user));
              
                return RedirectToAction("AllTickets");

            }
            return View();
        }



    }
}
