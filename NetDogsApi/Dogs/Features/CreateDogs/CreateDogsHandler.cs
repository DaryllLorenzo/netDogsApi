using MediatR;
using NetDogsApi.Dogs.Models;
using NetDogsApi.Dogs.ValueObjects;
using NetDogsApi.Shared.Data;

namespace NetDogsApi.Dogs.Features.CreateDogs;

public class CreateDogHandler(NetDogsApiDbContext dbContext)
    : IRequestHandler<CreateDogCommand, CreateDogResponse>
{
    public async Task<CreateDogResponse> Handle(CreateDogCommand request, CancellationToken cancellationToken)
    {
        var dog = Dog.Create(DogId.New(), request.Name);
        
        await dbContext.Dogs.AddAsync(dog, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return new CreateDogResponse(dog.Id);
    }
}