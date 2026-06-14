using NetDogsApi.Dogs.ValueObjects;

namespace NetDogsApi.Dogs.Models;

public class Dog
{
    private Dog() { }

    private Dog(DogId id, string name)
    {
        Id = id;
        Name = name;
    }

    public DogId Id { get; private set; } = default!;
    public string Name { get; private set; } = default!;

    public static Dog Create(DogId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        return new Dog(id, name);
    }

    public void Update(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        Name = name;
    }
}