using Store_BootCamp.Application.Services.Interfaces;
using Store_BootCamp.Domain.InterfacesRepository;

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
    }
}
