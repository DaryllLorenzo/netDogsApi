using FluentValidation;
using MediatR;

namespace NetDogsApi.Dogs.Features.CreateDogs;

public record CreateDogCommand(string Name) : IRequest<CreateDogResponse>;

public class CreateDogCommandValidator : AbstractValidator<CreateDogCommand>
{
    public CreateDogCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MaximumLength(200)
            .WithMessage("Name must not exceed 200 characters");
    }
}