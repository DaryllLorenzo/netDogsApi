using NetDogsApi.Dogs.Features.GetDogs;
using NetDogsApi.Dogs.Features.CreateDogs;

namespace NetDogsApi.Dogs;

internal static class DogsConfigurations
{
    public const string Tag = "Dogs";
    public const string PrefixUri = "/api/dogs";

    internal static IEndpointRouteBuilder MapDogsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var dogs = endpoints.MapGroup(PrefixUri).WithTags(Tag);
        
        dogs.MapGetDogsEndpoint();
        dogs.MapCreateDogEndpoint();
        // dogs.MapGetDogByIdEndpoint();
        // dogs.MapUpdateDogEndpoint();
        // dogs.MapDeleteDogEndpoint();
        
        return endpoints;
    }
}