using Microsoft.EntityFrameworkCore;
using NetDogsApi.Dogs.Models;
using NetDogsApi.Dogs.ValueObjects;

namespace NetDogsApi.Shared.Data;

public class NetDogsApiDataSeeder(NetDogsApiDbContext context, ILogger<NetDogsApiDataSeeder> logger)
{
    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        if (await context.Dogs.AnyAsync(cancellationToken))
        {
            logger.LogInformation("Database already has data, skipping seed.");
            return;
        }

        logger.LogInformation("Seeding database...");

        var dogs = new[]
        {
            Dog.Create(DogId.Of(Guid.NewGuid()), "Firulais"),
            Dog.Create(DogId.Of(Guid.NewGuid()), "Rex"),
            Dog.Create(DogId.Of(Guid.NewGuid()), "Lassie"),
        };

        await context.Dogs.AddRangeAsync(dogs, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Database seeded with {Count} dogs.", dogs.Length);
    }
}