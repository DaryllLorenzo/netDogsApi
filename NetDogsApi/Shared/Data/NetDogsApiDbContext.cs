using Microsoft.EntityFrameworkCore;
using NetDogsApi.Dogs.Models;
using NetDogsApi.Shared.Contracts;

namespace NetDogsApi.Shared.Data;

public class NetDogsApiDbContext(DbContextOptions<NetDogsApiDbContext> options)
    : DbContext(options), INetDogsApiDbContext // We implement the INetDogsApiDbContext interface to ensure our DbContext has the required members
{
    // We need to implement the members of INetDogsApiDbContext, but since DbContext already has a Set<TEntity>() method, we don't need to do anything for that one. We just need to add the Dogs DbSet and the SaveChangesAsync method.
    public DbSet<Dog> Dogs { get; set; } = default!;

    // We need to implement SaveChangesAsync to save changes to the database, and we can just call the base implementation from DbContext
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NetDogsApiDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}