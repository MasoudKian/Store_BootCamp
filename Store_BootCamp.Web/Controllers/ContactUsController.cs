using Microsoft.AspNetCore.Mvc;
using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Application.ViewModels.ContactUs;
using Store_BootCamp.Web.Extentions;

namespace Store_BootCamp.Web.Controllers
{
    public class ContactUsController : Controller
    {
        #region Constructor

        private readonly IContactService _contactService;
        public ContactUsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        #endregion

        [HttpGet("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost("ContactUs")]
        public IActionResult ContactUs(CreateContactUsViewModel createContact)
        {
            if (!ModelState.IsValid) return View(createContact);

            var userIp = HttpContext.Connection.RemoteIpAddress!.ToString();


            _contactService.CreateContactUs(createContact,userIp,User.GetUserId());

            ViewBag.Sucess = true;  

            return View(createContact);
        }
    }
}
