namespace NetDogsApi.Dogs.ValueObjects;

public record DogId
{
    public Guid Value { get; }

    // private constructor to enforce the use of the factory method
    private DogId(Guid value) => Value = value;

    // factory method to create a new DogId
    public static DogId Of(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("DogId cannot be empty.", nameof(id));

        return new DogId(id);
    }

    // convenience method to create a new DogId with a new GUID
    public static DogId New() => new(Guid.NewGuid());

    // implicit conversions for convenience
    public static implicit operator Guid(DogId id) => id.Value;
    public static implicit operator DogId(Guid id) => Of(id);

    // override ToString for better readability
    public override string ToString() => Value.ToString();
}