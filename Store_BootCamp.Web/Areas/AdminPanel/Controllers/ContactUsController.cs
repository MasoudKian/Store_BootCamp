using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Application.ViewModels.ContactUs;

namespace Store_BootCamp.Web.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ContactUsController : Controller
    {
        private readonly IContactService _contactService;
        public ContactUsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult SiteMessages()
        {
            var messageList = _contactService.GetListContactUs();

            return View(messageList);
        }

        [HttpGet]
        public IActionResult GetMessageDetails(int id)
        {
            var contactUs = _contactService.GetContactUsById(id);
            return Json(contactUs); // بازگرداندن اطلاعات به صورت JSON
        }


        [HttpGet]
        public IActionResult Reply(int userId, string userEmail)
        {
            var replyViewModel = new ReplyViewModel
            {
                UserId = userId,
                UserEmail = userEmail
            };

            return View(replyViewModel);
        }

    }
}
