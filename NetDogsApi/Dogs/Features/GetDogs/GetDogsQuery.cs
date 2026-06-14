using FluentValidation;
using MediatR;
using Sieve.Models;

namespace NetDogsApi.Dogs.Features.GetDogs;

/// <summary>
/// Query to get paginated list of dogs with filtering and sorting.
/// </summary>
public record GetDogsQuery(SieveModel SieveModel) : IRequest<GetDogsResponse>;

public class GetDogsQueryValidator : AbstractValidator<GetDogsQuery>
{
    public GetDogsQueryValidator()
    {
        RuleFor(x => x.SieveModel.Page)
            .GreaterThanOrEqualTo(1).When(x => x.SieveModel.Page.HasValue)
            .WithMessage("Page must be greater than or equal to 1");
        
        RuleFor(x => x.SieveModel.PageSize)
            .GreaterThanOrEqualTo(1).When(x => x.SieveModel.PageSize.HasValue)
            .WithMessage("PageSize must be greater than or equal to 1");
    }
}