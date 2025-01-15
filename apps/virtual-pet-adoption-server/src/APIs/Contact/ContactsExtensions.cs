using VirtualPetAdoption.APIs.Dtos;
using VirtualPetAdoption.Infrastructure.Models;

namespace VirtualPetAdoption.APIs.Extensions;

public static class ContactsExtensions
{
    public static Contact ToDto(this ContactDbModel model)
    {
        return new Contact
        {
            CreatedAt = model.CreatedAt,
            Email = model.Email,
            Id = model.Id,
            Message = model.Message,
            SentAt = model.SentAt,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ContactDbModel ToModel(
        this ContactUpdateInput updateDto,
        ContactWhereUniqueInput uniqueId
    )
    {
        var contact = new ContactDbModel
        {
            Id = uniqueId.Id,
            Email = updateDto.Email,
            Message = updateDto.Message,
            SentAt = updateDto.SentAt
        };

        if (updateDto.CreatedAt != null)
        {
            contact.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            contact.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return contact;
    }
}
