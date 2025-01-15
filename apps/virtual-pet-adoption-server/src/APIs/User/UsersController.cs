using Microsoft.AspNetCore.Mvc;

namespace VirtualPetAdoption.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}
