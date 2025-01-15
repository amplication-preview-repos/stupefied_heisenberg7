using Microsoft.AspNetCore.Mvc;

namespace VirtualPetAdoption.APIs;

[ApiController()]
public class ContactsController : ContactsControllerBase
{
    public ContactsController(IContactsService service)
        : base(service) { }
}
