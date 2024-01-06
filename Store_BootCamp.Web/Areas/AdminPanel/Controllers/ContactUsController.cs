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
            return Json(contactUs); 
        }

        [HttpGet]
        public ActionResult Reply(int id,string email)
        {
            
            var contactUs = _contactService.GetContactUsById(id);

            if (contactUs == null)
            {
                
                return NotFound();
            }

            var replyViewModel = new ReplyViewModel
            {
                ContactUsId = contactUs.Id,
                Email = contactUs.Email
            };

            return View(replyViewModel);
        }
        [HttpPost]
        public ActionResult Reply(ReplyViewModel replyViewModel)
        {
            if (ModelState.IsValid)
            {
                
                _contactService.ReplyToContact(replyViewModel, "masoudkiannezhad@gmail.com");

                    ViewBag.SuccessMessage = true;
                

                return View(replyViewModel);
            }

            
            return View(replyViewModel);
        }


    }
}
