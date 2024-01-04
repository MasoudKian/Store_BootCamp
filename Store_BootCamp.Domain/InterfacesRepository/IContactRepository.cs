using Store_BootCamp.Domain.Models.Contacts;

namespace Store_BootCamp.Domain.InterfacesRepository
{
    public interface IContactRepository
    {
        ContactUs GetContactUsById(int id);

        ContactUs GetContactUsByEmail(string email);

        List<ContactUs> GetAllContactUs(); 

        int AddContactUs(ContactUs contactUs);

        void UpdateContactUs(ContactUs contactUs);

        void DeleteContactUs(int id);
    }
}
