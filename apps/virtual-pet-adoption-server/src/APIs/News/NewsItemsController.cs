using Microsoft.AspNetCore.Mvc;

namespace VirtualPetAdoption.APIs;

[ApiController()]
public class NewsItemsController : NewsItemsControllerBase
{
    public NewsItemsController(INewsItemsService service)
        : base(service) { }
}
