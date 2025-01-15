using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualPetAdoption.Core.Enums;

namespace VirtualPetAdoption.Infrastructure.Models;

[Table("Users")]
public class UserDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    [StringLength(256)]
    public string? FirstName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(256)]
    public string? LastName { get; set; }

    [Required()]
    public string Password { get; set; }

    [Required()]
    public string Roles { get; set; }

    public SubscriptionLevelEnum? SubscriptionLevel { get; set; }

    public SubscriptionStatusEnum? SubscriptionStatus { get; set; }

    public List<SubscriptionDbModel>? Subscriptions { get; set; } = new List<SubscriptionDbModel>();

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [Required()]
    public string Username { get; set; }
}
