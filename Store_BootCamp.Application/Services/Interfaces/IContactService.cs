using Store_BootCamp.Application.ViewModels.ContactUs;

namespace Store_BootCamp.Application.Services.Interfaces
{
    public interface IContactService
    {
        void CreateContactUs(CreateContactUsViewModel contact , string userIp , int ? userId);
    }
}
