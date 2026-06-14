namespace NetDogsApi.Dogs.Features.GetDogs;

public record GetDogsResponse(
    IReadOnlyList<DogDto> Items,
    int TotalCount,
    int CurrentPage,
    int PageSize
)
{
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool HasNextPage => CurrentPage < TotalPages;
    public bool HasPreviousPage => CurrentPage > 1;
}

public record DogDto(Guid Id, string Name);