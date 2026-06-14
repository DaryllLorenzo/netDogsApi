using MediatR;

namespace NetDogsApi.Dogs.Features.CreateDogs;

public static class CreateDogsEndpoint
{
        public static void MapCreateDogEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/dogs", async (
            CreateDogCommand command,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            return Results.Created($"/api/dogs/{result.Id}", result);
        })
        .WithName("CreateDog")
        .WithTags(DogsConfigurations.Tag)
        .WithSummary("Create a new dog")
        .WithDescription("Creates a new dog and returns the created resource location");
    }
}