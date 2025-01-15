using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPetAdoption.Core.Enums;

namespace VirtualPetAdoption.Infrastructure.Models;

[Table("Pets")]
public class PetDbModel
{
    [StringLength(1000)]
    public string? Bio { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    public DateTime? DateOfBirth { get; set; }

    [StringLength(1000)]
    public string? HealthCondition { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Location { get; set; }

    public string? MainGalleryPhotos { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [Range(-999999999, 999999999)]
    public int? NumberOfOwners { get; set; }

    public PersonalityTraitsEnum? PersonalityTraits { get; set; }

    public List<SubscriptionDbModel>? Subscriptions { get; set; } = new List<SubscriptionDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
