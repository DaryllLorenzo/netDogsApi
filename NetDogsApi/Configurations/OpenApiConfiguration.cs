using Microsoft.OpenApi;

namespace NetDogsApi.Configurations;

public static class OpenApiConfiguration
{
    public static void AddOpenApiWithOptions(this IServiceCollection services)
    {
        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, _) =>
            {
                // Order tags alphabetically
                document.Tags = document.Tags?
                    .OrderBy(t => t.Name)
                    .ToHashSet();

                // Order paths alphabetically
                var sorted = document.Paths
                    .OrderBy(p => p.Key)
                    .ToDictionary(p => p.Key, p => p.Value);

                document.Paths = new OpenApiPaths();
                foreach (var (key, value) in sorted)
                    document.Paths.Add(key, value);

                return Task.CompletedTask;
            });
        });
    }
}