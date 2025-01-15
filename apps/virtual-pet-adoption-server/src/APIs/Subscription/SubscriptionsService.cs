using VirtualPetAdoption.Infrastructure;

namespace VirtualPetAdoption.APIs;

public class SubscriptionsService : SubscriptionsServiceBase
{
    public SubscriptionsService(VirtualPetAdoptionDbContext context)
        : base(context) { }
}
