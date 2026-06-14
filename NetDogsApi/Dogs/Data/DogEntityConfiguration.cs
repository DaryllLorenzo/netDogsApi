using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetDogsApi.Dogs.Models;
using NetDogsApi.Dogs.ValueObjects;

namespace NetDogsApi.Dogs.Data;

public class DogEntityConfiguration : IEntityTypeConfiguration<Dog>
{
    public void Configure(EntityTypeBuilder<Dog> builder)
    {
        builder.ToTable("dogs");

        builder.HasKey(x => x.Id);

        // we tell EF how to convert between DogId and Guid
        // because EF doesn't know how to work with strongly-typed IDs by default
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,       // DogId → Guid (for writing)
                value => DogId.Of(value) // Guid → DogId (for reading)
            );

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(200);
    }
}