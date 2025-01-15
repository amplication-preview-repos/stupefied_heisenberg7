using VirtualPetAdoption.APIs.Common;
using VirtualPetAdoption.APIs.Dtos;

namespace VirtualPetAdoption.APIs;

public interface IPetsService
{
    /// <summary>
    /// Create one Pet
    /// </summary>
    public Task<Pet> CreatePet(PetCreateInput pet);

    /// <summary>
    /// Delete one Pet
    /// </summary>
    public Task DeletePet(PetWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Pets
    /// </summary>
    public Task<List<Pet>> Pets(PetFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Pet records
    /// </summary>
    public Task<MetadataDto> PetsMeta(PetFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Pet
    /// </summary>
    public Task<Pet> Pet(PetWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Pet
    /// </summary>
    public Task UpdatePet(PetWhereUniqueInput uniqueId, PetUpdateInput updateDto);

    /// <summary>
    /// Connect multiple Subscriptions records to Pet
    /// </summary>
    public Task ConnectSubscriptions(
        PetWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] subscriptionsId
    );

    /// <summary>
    /// Disconnect multiple Subscriptions records from Pet
    /// </summary>
    public Task DisconnectSubscriptions(
        PetWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] subscriptionsId
    );

    /// <summary>
    /// Find multiple Subscriptions records for Pet
    /// </summary>
    public Task<List<Subscription>> FindSubscriptions(
        PetWhereUniqueInput uniqueId,
        SubscriptionFindManyArgs SubscriptionFindManyArgs
    );

    /// <summary>
    /// Update multiple Subscriptions records for Pet
    /// </summary>
    public Task UpdateSubscriptions(
        PetWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] subscriptionsId
    );
}
