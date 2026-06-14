using NetDogsApi.Dogs.Models;
using Sieve.Services;

namespace NetDogsApi.Dogs.Data;

public class SieveDogReadConfiguration : ISieveConfiguration
{
    public void Configure(SievePropertyMapper mapper)
    {
        mapper.Property<Dog>(d => d.Id.Value)
            .CanFilter()
            .CanSort()
            .HasName("id");

        mapper.Property<Dog>(d => d.Name)
            .CanFilter()
            .CanSort()
            .HasName("name");
    }
}