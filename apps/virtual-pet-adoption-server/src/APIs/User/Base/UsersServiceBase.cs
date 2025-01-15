using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.APIs;
using VirtualPetAdoption.APIs.Common;
using VirtualPetAdoption.APIs.Dtos;
using VirtualPetAdoption.APIs.Errors;
using VirtualPetAdoption.APIs.Extensions;
using VirtualPetAdoption.Infrastructure;
using VirtualPetAdoption.Infrastructure.Models;

namespace VirtualPetAdoption.APIs;

public abstract class UsersServiceBase : IUsersService
{
    protected readonly VirtualPetAdoptionDbContext _context;

    public UsersServiceBase(VirtualPetAdoptionDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one User
    /// </summary>
    public async Task<User> CreateUser(UserCreateInput createDto)
    {
        var user = new UserDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Email = createDto.Email,
            FirstName = createDto.FirstName,
            LastName = createDto.LastName,
            Password = createDto.Password,
            Roles = createDto.Roles,
            SubscriptionLevel = createDto.SubscriptionLevel,
            SubscriptionStatus = createDto.SubscriptionStatus,
            UpdatedAt = createDto.UpdatedAt,
            Username = createDto.Username
        };

        if (createDto.Id != null)
        {
            user.Id = createDto.Id;
        }
        if (createDto.Subscriptions != null)
        {
            user.Subscriptions = await _context
                .Subscriptions.Where(subscription =>
                    createDto.Subscriptions.Select(t => t.Id).Contains(subscription.Id)
                )
                .ToListAsync();
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<UserDbModel>(user.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one User
    /// </summary>
    public async Task DeleteUser(UserWhereUniqueInput uniqueId)
    {
        var user = await _context.Users.FindAsync(uniqueId.Id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Users
    /// </summary>
    public async Task<List<User>> Users(UserFindManyArgs findManyArgs)
    {
        var users = await _context
            .Users.Include(x => x.Subscriptions)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return users.ConvertAll(user => user.ToDto());
    }

    /// <summary>
    /// Meta data about User records
    /// </summary>
    public async Task<MetadataDto> UsersMeta(UserFindManyArgs findManyArgs)
    {
        var count = await _context.Users.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one User
    /// </summary>
    public async Task<User> User(UserWhereUniqueInput uniqueId)
    {
        var users = await this.Users(
            new UserFindManyArgs { Where = new UserWhereInput { Id = uniqueId.Id } }
        );
        var user = users.FirstOrDefault();
        if (user == null)
        {
            throw new NotFoundException();
        }

        return user;
    }

    /// <summary>
    /// Update one User
    /// </summary>
    public async Task UpdateUser(UserWhereUniqueInput uniqueId, UserUpdateInput updateDto)
    {
        var user = updateDto.ToModel(uniqueId);

        if (updateDto.Subscriptions != null)
        {
            user.Subscriptions = await _context
                .Subscriptions.Where(subscription =>
                    updateDto.Subscriptions.Select(t => t).Contains(subscription.Id)
                )
                .ToListAsync();
        }

        _context.Entry(user).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Users.Any(e => e.Id == user.Id))
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
    /// Connect multiple Subscriptions records to User
    /// </summary>
    public async Task ConnectSubscriptions(
        UserWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.Subscriptions)
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
    /// Disconnect multiple Subscriptions records from User
    /// </summary>
    public async Task DisconnectSubscriptions(
        UserWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .Users.Include(x => x.Subscriptions)
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
    /// Find multiple Subscriptions records for User
    /// </summary>
    public async Task<List<Subscription>> FindSubscriptions(
        UserWhereUniqueInput uniqueId,
        SubscriptionFindManyArgs userFindManyArgs
    )
    {
        var subscriptions = await _context
            .Subscriptions.Where(m => m.UserId == uniqueId.Id)
            .ApplyWhere(userFindManyArgs.Where)
            .ApplySkip(userFindManyArgs.Skip)
            .ApplyTake(userFindManyArgs.Take)
            .ApplyOrderBy(userFindManyArgs.SortBy)
            .ToListAsync();

        return subscriptions.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Subscriptions records for User
    /// </summary>
    public async Task UpdateSubscriptions(
        UserWhereUniqueInput uniqueId,
        SubscriptionWhereUniqueInput[] childrenIds
    )
    {
        var user = await _context
            .Users.Include(t => t.Subscriptions)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (user == null)
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

        user.Subscriptions = children;
        await _context.SaveChangesAsync();
    }
}
