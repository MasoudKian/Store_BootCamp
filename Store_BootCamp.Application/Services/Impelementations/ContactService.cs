using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Application.ViewModels.ContactUs;
using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Contacts;

namespace Store_BootCamp.Application.Services.Impelementations
{
    public class ContactService : IContactService
    {
        #region Constructor
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
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

        public void RespondToContactUsByEmail(string userEmail, ContactUsResponse response)
        {

        }
    }
}
