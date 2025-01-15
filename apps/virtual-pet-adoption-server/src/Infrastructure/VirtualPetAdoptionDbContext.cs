using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Infrastructure.Models;

namespace VirtualPetAdoption.Infrastructure;

public class VirtualPetAdoptionDbContext : DbContext
{
    public VirtualPetAdoptionDbContext(DbContextOptions<VirtualPetAdoptionDbContext> options)
        : base(options) { }

    public DbSet<PetDbModel> Pets { get; set; }

    public DbSet<SubscriptionDbModel> Subscriptions { get; set; }

    public DbSet<NewsDbModel> NewsItems { get; set; }

    public DbSet<ContactDbModel> Contacts { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
