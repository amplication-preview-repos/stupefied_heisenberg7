using VirtualPetAdoption.APIs.Dtos;
using VirtualPetAdoption.Infrastructure.Models;

namespace VirtualPetAdoption.APIs.Extensions;

public static class PetsExtensions
{
    public static Pet ToDto(this PetDbModel model)
    {
        return new Pet
        {
            Bio = model.Bio,
            CreatedAt = model.CreatedAt,
            DateOfBirth = model.DateOfBirth,
            HealthCondition = model.HealthCondition,
            Id = model.Id,
            Location = model.Location,
            MainGalleryPhotos = model.MainGalleryPhotos,
            Name = model.Name,
            NumberOfOwners = model.NumberOfOwners,
            PersonalityTraits = model.PersonalityTraits,
            Subscriptions = model.Subscriptions?.Select(x => x.Id).ToList(),
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static PetDbModel ToModel(this PetUpdateInput updateDto, PetWhereUniqueInput uniqueId)
    {
        var pet = new PetDbModel
        {
            Id = uniqueId.Id,
            Bio = updateDto.Bio,
            DateOfBirth = updateDto.DateOfBirth,
            HealthCondition = updateDto.HealthCondition,
            Location = updateDto.Location,
            MainGalleryPhotos = updateDto.MainGalleryPhotos,
            Name = updateDto.Name,
            NumberOfOwners = updateDto.NumberOfOwners,
            PersonalityTraits = updateDto.PersonalityTraits
        };

        if (updateDto.CreatedAt != null)
        {
            pet.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            pet.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return pet;
    }
}
