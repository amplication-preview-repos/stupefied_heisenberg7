using VirtualPetAdoption.Infrastructure;

namespace VirtualPetAdoption.APIs;

public class ContactsService : ContactsServiceBase
{
    public ContactsService(VirtualPetAdoptionDbContext context)
        : base(context) { }
}
