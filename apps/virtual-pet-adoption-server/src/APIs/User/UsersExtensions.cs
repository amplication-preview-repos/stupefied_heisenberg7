using VirtualPetAdoption.APIs.Dtos;
using VirtualPetAdoption.Infrastructure.Models;

namespace VirtualPetAdoption.APIs.Extensions;

public static class UsersExtensions
{
    public static User ToDto(this UserDbModel model)
    {
        return new User
        {
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            FirstName = model.FirstName,
            Id = model.Id,
            LastName = model.LastName,
            Password = model.Password,
            Roles = model.Roles,
            SubscriptionLevel = model.SubscriptionLevel,
            SubscriptionStatus = model.SubscriptionStatus,
            Subscriptions = model.Subscriptions?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
            Username = model.Username,
        };
    }

    public static UserDbModel ToModel(this UserUpdateInput updateDto, UserWhereUniqueInput uniqueId)
    {
        var user = new UserDbModel
        {
            Id = uniqueId.Id,
            Email = updateDto.Email,
            FirstName = updateDto.FirstName,
            LastName = updateDto.LastName,
            SubscriptionLevel = updateDto.SubscriptionLevel,
            SubscriptionStatus = updateDto.SubscriptionStatus
        };

        if (updateDto.CreatedAt != null)
        {
            user.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Password != null)
        {
            user.Password = updateDto.Password;
        }
        if (updateDto.Roles != null)
        {
            user.Roles = updateDto.Roles;
        }
        if (updateDto.UpdatedAt != null)
        {
            user.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.Username != null)
        {
            user.Username = updateDto.Username;
        }

        return user;
    }
}
