using VirtualPetAdoption.Core.Enums;

namespace VirtualPetAdoption.APIs.Dtos;

public class PetUpdateInput
{
    public string? Bio { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? HealthCondition { get; set; }

    public string? Id { get; set; }

    public string? Location { get; set; }

    public string? MainGalleryPhotos { get; set; }

    public string? Name { get; set; }

    public int? NumberOfOwners { get; set; }

    public PersonalityTraitsEnum? PersonalityTraits { get; set; }

    public List<string>? Subscriptions { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
