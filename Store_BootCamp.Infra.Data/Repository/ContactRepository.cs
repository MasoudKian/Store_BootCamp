using Store_BootCamp.Domain.InterfacesRepository;
using Store_BootCamp.Domain.Models.Contacts;
using Store_BootCamp.Infra.Data.Context;

namespace Store_BootCamp.Infra.Data.Repository
{
    public class ContactRepository : IContactRepository
    {
        #region Constractor

        private readonly StoreDBContext _context;
        public ContactRepository(StoreDBContext context)
        {
            _context = context;
        }
        #endregion


        public ContactUs GetContactUsById(int id)
        {
            var contactUs = _context.ContactUs.Find(id);
            return contactUs;
        }

        public ContactUs GetContactUsByEmail(string email)
        {
            var contactUsEmail = _context.ContactUs.Where(c => c.Email == email).Single();
            return contactUsEmail;
        }

        public List<ContactUs> GetAllContactUs()
        {
            var list = _context.ContactUs.ToList();
            return list;
        }

        public int AddContactUs(ContactUs contactUs)
        {
            _context.ContactUs.Add(contactUs);
            contactUs.CreateDate = DateTime.Now;
            _context.SaveChanges();
            return contactUs.Id;
        }

        public void UpdateContactUs(ContactUs contactUs)
        {
            _context.Update(contactUs);
            _context.SaveChanges();
        }

        public void DeleteContactUs(int id)
        {
            var contactUs = GetContactUsById(id);
            contactUs.IsDelete = true;

        }
    }
}
