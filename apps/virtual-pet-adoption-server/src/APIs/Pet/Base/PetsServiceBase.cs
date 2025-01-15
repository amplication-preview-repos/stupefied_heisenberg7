using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.APIs;
using VirtualPetAdoption.APIs.Common;
using VirtualPetAdoption.APIs.Dtos;
using VirtualPetAdoption.APIs.Errors;
using VirtualPetAdoption.APIs.Extensions;
using VirtualPetAdoption.Infrastructure;
using VirtualPetAdoption.Infrastructure.Models;

namespace VirtualPetAdoption.APIs;

public abstract class PetsServiceBase : IPetsService
{
    protected readonly VirtualPetAdoptionDbContext _context;

    public PetsServiceBase(VirtualPetAdoptionDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Pet
    /// </summary>
    public async Task<Pet> CreatePet(PetCreateInput createDto)
    {
        var pet = new PetDbModel
        {
            Bio = createDto.Bio,
            CreatedAt = createDto.CreatedAt,
            DateOfBirth = createDto.DateOfBirth,
            HealthCondition = createDto.HealthCondition,
            Location = createDto.Location,
            MainGalleryPhotos = createDto.MainGalleryPhotos,
            Name = createDto.Name,
            NumberOfOwners = createDto.NumberOfOwners,
            PersonalityTraits = createDto.PersonalityTraits,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            pet.Id = createDto.Id;
        }
        if (createDto.Subscriptions != null)
        {
            pet.Subscriptions = await _context
                .Subscriptions.Where(subscription =>
                    createDto.Subscriptions.Select(t => t.Id).Contains(subscription.Id)
                )
                .ToListAsync();
        }

        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PetDbModel>(pet.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Pet
    /// </summary>
    public async Task DeletePet(PetWhereUniqueInput uniqueId)
    {
        var pet = await _context.Pets.FindAsync(uniqueId.Id);
        if (pet == null)
        {
            throw new NotFoundException();
        }

        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Pets
    /// </summary>
    public async Task<List<Pet>> Pets(PetFindManyArgs findManyArgs)
    {
        var pets = await _context
            .Pets.Include(x => x.Subscriptions)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return pets.ConvertAll(pet => pet.ToDto());
    }

    /// <summary>
    /// Meta data about Pet records
    /// </summary>
    public async Task<MetadataDto> PetsMeta(PetFindManyArgs findManyArgs)
    {
        var count = await _context.Pets.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Pet
    /// </summary>
    public async Task<Pet> Pet(PetWhereUniqueInput uniqueId)
    {
        var pets = await this.Pets(
            new PetFindManyArgs { Where = new PetWhereInput { Id = uniqueId.Id } }
        );
        var pet = pets.FirstOrDefault();
        if (pet == null)
        {
            throw new NotFoundException();
        }

        return pet;
    }

    /// <summary>
    /// Update one Pet
    /// </summary>
    public async Task UpdatePet(PetWhereUniqueInput uniqueId, PetUpdateInput updateDto)
    {
        var pet = updateDto.ToModel(uniqueId);

        if (updateDto.Subscriptions != null)
        {
            pet.Subscriptions = await _context
                .Subscriptions.Where(subscription =>
                    updateDto.Subscriptions.Select(t => t).Contains(subscription.Id)
                )
                .ToListAsync();
        }

        _context.Entry(pet).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Pets.Any(e => e.Id == pet.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Connect multiple Subscriptions records to Pet
    /// </summary>
    public async Task ConnectSubscriptions(
        PetWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Pets.Include(x => x.Subscriptions)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Subscriptions.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Subscriptions);

        foreach (var child in childrenToConnect)
        {
            parent.Subscriptions.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Subscriptions records from Pet
    /// </summary>
    public async Task DisconnectSubscriptions(
        PetWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Pets.Include(x => x.Subscriptions)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Subscriptions.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Subscriptions?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Subscriptions records for Pet
    /// </summary>
    public async Task<List<Subscription>> FindSubscriptions(
        PetWhereUniqueInput uniqueId,
        SubscriptionFindManyArgs petFindManyArgs
    )
    {
        var subscriptions = await _context
            .Subscriptions.Where(m => m.PetId == uniqueId.Id)
            .ApplyWhere(petFindManyArgs.Where)
            .ApplySkip(petFindManyArgs.Skip)
            .ApplyTake(petFindManyArgs.Take)
            .ApplyOrderBy(petFindManyArgs.SortBy)
            .ToListAsync();

        return subscriptions.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Subscriptions records for Pet
    /// </summary>
    public async Task UpdateSubscriptions(
        PetWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] childrenIds
    )
    {
        var pet = await _context
            .Pets.Include(t => t.Subscriptions)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (pet == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Subscriptions.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        pet.Subscriptions = children;
        await _context.SaveChangesAsync();
    }
}
