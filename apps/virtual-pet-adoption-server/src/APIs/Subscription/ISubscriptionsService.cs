using VirtualPetAdoption.APIs.Common;
using VirtualPetAdoption.APIs.Dtos;

namespace VirtualPetAdoption.APIs;

public interface ISubscriptionsService
{
    /// <summary>
    /// Create one Subscription
    /// </summary>
    public Task<Subscription> CreateSubscription(SubscriptionCreateInput subscription);

    /// <summary>
    /// Delete one Subscription
    /// </summary>
    public Task DeleteSubscription(SubscriptionWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Subscriptions
    /// </summary>
    public Task<List<Subscription>> Subscriptions(SubscriptionFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Subscription records
    /// </summary>
    public Task<MetadataDto> SubscriptionsMeta(SubscriptionFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Subscription
    /// </summary>
    public Task<Subscription> Subscription(SubscriptionWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Subscription
    /// </summary>
    public Task UpdateSubscription(
        SubscriptionWhereUniqueInput uniqueId,
        SubscriptionUpdateInput updateDto
    );

    /// <summary>
    /// Get a Pet record for Subscription
    /// </summary>
    public Task<Pet> GetPet(SubscriptionWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a User record for Subscription
    /// </summary>
    public Task<User> GetUser(SubscriptionWhereUniqueInput uniqueId);
}
