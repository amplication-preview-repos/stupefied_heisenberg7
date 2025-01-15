using VirtualPetAdoption.Infrastructure;

namespace VirtualPetAdoption.APIs;

public class PetsService : PetsServiceBase
{
    public PetsService(VirtualPetAdoptionDbContext context)
        : base(context) { }
}
