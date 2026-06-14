using Microsoft.EntityFrameworkCore;

namespace NetDogsApi.Shared.Data;

public static class DatabaseInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider, IConfiguration configuration, CancellationToken cancellationToken = default)
    {
        using var scope = serviceProvider.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<NetDogsApiDbContext>();
        var seeder = scope.ServiceProvider.GetRequiredService<NetDogsApiDataSeeder>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<NetDogsApiDbContext>>();

        var recreate = configuration.GetValue<bool>("Database:RecreateOnStartup");
        var seed = configuration.GetValue<bool>("Database:SeedOnStartup");

        if (recreate)
        {
            logger.LogWarning("Recreating database...");
            await context.Database.EnsureDeletedAsync(cancellationToken);
            logger.LogInformation("Database deleted.");
        }

        await context.Database.MigrateAsync(cancellationToken);
        logger.LogInformation("Migrations applied.");

        if (seed)
            await seeder.SeedAsync(cancellationToken);
    }
}