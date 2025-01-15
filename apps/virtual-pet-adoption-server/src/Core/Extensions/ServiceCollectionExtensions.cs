using VirtualPetAdoption.APIs;

namespace VirtualPetAdoption;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IContactsService, ContactsService>();
        services.AddScoped<INewsService, NewsService>();
        services.AddScoped<IPetsService, PetsService>();
        services.AddScoped<ISubscriptionsService, SubscriptionsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
