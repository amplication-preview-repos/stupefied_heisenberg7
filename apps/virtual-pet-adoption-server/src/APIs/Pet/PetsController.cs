using Microsoft.AspNetCore.Mvc;

namespace VirtualPetAdoption.APIs;

[ApiController()]
public class PetsController : PetsControllerBase
{
    public PetsController(IPetsService service)
        : base(service) { }
}
