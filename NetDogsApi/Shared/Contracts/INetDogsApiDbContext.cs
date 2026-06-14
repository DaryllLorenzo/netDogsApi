using Microsoft.EntityFrameworkCore;
using NetDogsApi.Dogs.Models;

namespace NetDogsApi.Shared.Contracts;

public interface INetDogsApiDbContext
{
    // This method is required by EF Core to work with the DbContext, but we don't need to implement it explicitly
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    // We expose DbSet<Dog> directly for convenience, but we could also just use Set<Dog>() in the repository
    DbSet<Dog> Dogs { get; }

    // This method is required to save changes to the database, and we need to implement it in our DbContext class
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}