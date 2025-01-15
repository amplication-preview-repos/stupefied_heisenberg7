using VirtualPetAdoption.Core.Enums;

namespace VirtualPetAdoption.APIs.Dtos;

public class Subscription
{
    public DateTime CreatedAt { get; set; }

    public DateTime? EndDate { get; set; }

    public string Id { get; set; }

    public string? Pet { get; set; }

    public DateTime? StartDate { get; set; }

    public StatusEnum? Status { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? User { get; set; }
}
