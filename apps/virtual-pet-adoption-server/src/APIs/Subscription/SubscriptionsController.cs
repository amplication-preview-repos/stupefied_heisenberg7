using Microsoft.AspNetCore.Mvc;

namespace VirtualPetAdoption.APIs;

[ApiController()]
public class SubscriptionsController : SubscriptionsControllerBase
{
    public SubscriptionsController(ISubscriptionsService service)
        : base(service) { }
}
