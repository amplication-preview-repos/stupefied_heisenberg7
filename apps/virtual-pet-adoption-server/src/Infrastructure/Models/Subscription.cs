using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPetAdoption.Core.Enums;

namespace VirtualPetAdoption.Infrastructure.Models;

[Table("Subscriptions")]
public class SubscriptionDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public DateTime? EndDate { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public string? PetId { get; set; }

    [ForeignKey(nameof(PetId))]
    public PetDbModel? Pet { get; set; } = null;

    public DateTime? StartDate { get; set; }

    public StatusEnum? Status { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;
}
