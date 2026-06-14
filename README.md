# Start API
- dotnet run
- dotnet watch run

## NuGet Packages

### Postgres and EF
* **Npgsql.EntityFrameworkCore.PostgreSQL** - PostgreSQL provider for EF Core, enables database communication
* **Microsoft.EntityFrameworkCore** - Core ORM for .NET, allows working with DB using .NET objects
* **Microsoft.EntityFrameworkCore.Design** - Shared design-time components for Entity Framework Core tools.

### MediatR (CQRS and Mediator)
* **MediatR** - Implements Mediator pattern, routes commands/queries to handlers, enables CQRS

### Validations
* **FluentValidation** - Fluent validation library, separates validation rules from business logic
* **FluentValidation.DependencyInjectionExtensions** - Auto-registers validators in DI container

### Env Variables
* **DotNetEnv** - For using .env variables

### Scalar
* **Scalar.AspNetCore** - Generate beautiful interactive API documentation from OpenAPI/Swagger documents.

### Sieve
* **Sieve** - Adds sorting, filtering, and pagination


## Run EF migrations
- dotnet ef migrations add InitialCreate --output-dir Shared/Data/Migrations
- dotnet ef database update (when DATABASE__RECREATE_ON_STARTUP = False)