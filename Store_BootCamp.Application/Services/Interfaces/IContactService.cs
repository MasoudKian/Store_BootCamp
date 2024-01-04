using Store_BootCamp.Application.ViewModels.ContactUs;
using Store_BootCamp.Domain.Models.Contacts;

namespace Store_BootCamp.Application.Services.Interfaces
{
    public interface IContactService
    {
        void CreateContactUs(CreateContactUsViewModel contact , string userIp , int ? userId);

        void RespondToContactUsByEmail(string userEmail, ContactUsResponse response);
    }
}
