using NetDogsApi.Dogs.Models;
using NetDogsApi.Dogs.Features.GetDogs;

namespace NetDogsApi.Dogs;

internal static class ManualDogMappings
{
    // Single entity mapping
    public static DogDto ToDogDto(this Dog dog)
    {
        ArgumentNullException.ThrowIfNull(dog);
        return new DogDto(dog.Id, dog.Name);
    }

    // Queryable projection mapping (for EF Core)
    public static IQueryable<DogDto> ToDogDto(this IQueryable<Dog> dogs)
    {
        return dogs.Select(dog => new DogDto(dog.Id, dog.Name));
    }
}