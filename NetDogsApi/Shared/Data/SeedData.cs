namespace NetDogsApi.Shared.Data;

public class SeedData
{
    public List<DogData> Dogs { get; set; } = [];

    public class DogData
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}