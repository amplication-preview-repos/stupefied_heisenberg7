using VirtualPetAdoption.Infrastructure;

namespace VirtualPetAdoption.APIs;

public class NewsItemsService : NewsItemsServiceBase
{
    public NewsItemsService(VirtualPetAdoptionDbContext context)
        : base(context) { }
}
