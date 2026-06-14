using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NetDogsApi.Shared.Data;

public class NetDogsApiDbContextDesignFactory : IDesignTimeDbContextFactory<NetDogsApiDbContext>
{
    public NetDogsApiDbContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory ?? "")
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' not found. " +
                "Make sure it is set in appsettings.json or via environment variables."
            );

        var optionsBuilder = new DbContextOptionsBuilder<NetDogsApiDbContext>()
            .UseNpgsql(connectionString, options =>
            {
                options.MigrationsAssembly(typeof(NetDogsApiDbContext).Assembly.FullName);
                options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), errorCodesToAdd: null);
            });

        return new NetDogsApiDbContext(optionsBuilder.Options);
    }
}