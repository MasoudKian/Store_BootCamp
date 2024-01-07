using Store_BootCamp.Application.Convertor;
using Store_BootCamp.Application.Senders;
using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Application.ViewModels.ContactUs;
using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Account;
using Store_BootCamp.Domain.Models.Contacts;

namespace Store_BootCamp.Application.Services.Impelementations
{
    public class ContactService : IContactService
    {
        #region Constructor
        private readonly IContactRepository _contactRepository;
        private readonly IViewRenderService _viewRender;

        public ContactService(IContactRepository contactRepository,IViewRenderService viewRender)
        {
            _contactRepository = contactRepository;
            _viewRender = viewRender;
        }

        #endregion

        public void CreateContactUs(CreateContactUsViewModel contact, string userIp, int? userId)
        {
            var newContact = new ContactUs()
            {
                UserId = userId,
                UserIp = userIp,
                FullName = contact.FullName,
                Email = contact.Email,
                Phone = contact.Phone,
                Title = contact.Title,
                Description = contact.Description,
                FileTicket = contact.FileTicket,
            };

            _contactRepository.AddContactUs(newContact); 
        }

        public List<ContactUs> GetListContactUs()
        {
            return _contactRepository.GetAllContactUs();
        }

        public ContactUs GetContactUsById(int id)
        {
            var contactUsId = _contactRepository.GetContactUsById(id);
            return contactUsId;
        }
        public void ReplyToContact(ReplyViewModel replyViewModel, string adminEmail)
        {
            
            var contactUs = _contactRepository.GetContactUsById(replyViewModel.ContactUsId);

            if (contactUs == null)
            {
                return ;
            }

            
            var response = new ContactUsResponse
            {
                ResponseMessage = replyViewModel.ResponseMessage,
                ContactUs = contactUs,
                EmailUser = replyViewModel.Email

            };

            contactUs.Response = response;
            _contactRepository.UpdateContactUs(contactUs);


            string body = _viewRender.RenderToStringAsync("_Answer", response);
            SendEmail.SendAnswer(contactUs.Email, "پاسخ به پیام شما", body);
        }

        public ReplyViewModel GetInformationMessageForAdmin(int id, string email)
        {
            var contactUs = GetContactUsById(id);

            var replyViewModel = new ReplyViewModel
            {
                ContactUsId = contactUs.Id,
                Email = contactUs.Email,
            };
            return replyViewModel;
        }
    }
}
