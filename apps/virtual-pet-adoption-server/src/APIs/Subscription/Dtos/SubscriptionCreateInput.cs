using VirtualPetAdoption.Core.Enums;

namespace VirtualPetAdoption.APIs.Dtos;

public class SubscriptionCreateInput
{
    public DateTime CreatedAt { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Id { get; set; }

    public Pet? Pet { get; set; }

    public DateTime? StartDate { get; set; }

    public StatusEnum? Status { get; set; }

    public DateTime UpdatedAt { get; set; }

    public User? User { get; set; }
}
