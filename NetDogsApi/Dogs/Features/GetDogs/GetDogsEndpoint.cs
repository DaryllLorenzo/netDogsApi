using MediatR;
using Sieve.Models;

namespace NetDogsApi.Dogs.Features.GetDogs;

public static class GetDogsEndpoint
{
    public static void MapGetDogsEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/dogs", async (
            [AsParameters] SieveModel sieveModel,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var query = new GetDogsQuery(sieveModel);
            var result = await mediator.Send(query, cancellationToken);
            return Results.Ok(result);
        })
        .WithName("GetDogs")
        .WithTags("Dogs")
        .WithSummary("Get paginated list of dogs")
        .WithDescription("Returns a paginated list of dogs with filtering, sorting, and pagination support");
    }
}