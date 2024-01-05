using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Services.Interfaces;

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
    }
}
