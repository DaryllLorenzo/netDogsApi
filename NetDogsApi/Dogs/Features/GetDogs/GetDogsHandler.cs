using MediatR;
using Microsoft.EntityFrameworkCore;
using NetDogsApi.Shared.Data;
using Sieve.Services;

namespace NetDogsApi.Dogs.Features.GetDogs;

public class GetDogsHandler(
    NetDogsApiDbContext dbContext,
    ISieveProcessor sieveProcessor
) : IRequestHandler<GetDogsQuery, GetDogsResponse>
{
    public async Task<GetDogsResponse> Handle(GetDogsQuery request, CancellationToken cancellationToken)
    {
        var query = dbContext.Dogs.AsNoTracking();
        
        // Apply filters and sorting (without pagination)
        var processed = sieveProcessor.Apply(request.SieveModel, query, applyPagination: false);
        
        // Get total count
        var totalCount = await processed.CountAsync(cancellationToken);
        
        // Apply pagination
        var page = request.SieveModel.Page ?? 1;
        var pageSize = request.SieveModel.PageSize ?? 10;
        
        var items = await processed
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(dog => dog.ToDogDto())
            .ToListAsync(cancellationToken);
        
        return new GetDogsResponse(items, totalCount, page, pageSize);
    }
}