using VirtualPetAdoption.Infrastructure;

namespace VirtualPetAdoption.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(VirtualPetAdoptionDbContext context)
        : base(context) { }
}
