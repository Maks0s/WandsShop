# Wand's Shop API
### ASP.NET Core web API project with features of:
- Clean architecture
- CQRS
- All default CRUD operations
- Database integration
- JWT authetication
- Custom error handling
- Model validation
- Logging
- Mapping

### Used technologies:
- ASP.Net Core (Web API framework)
- Swagger/OpenApi (API test/documentation)
- MediatR (CQRS/Logging&Validation pipeline behavior)
- Entity framework Core (ORM)
- MS SQL Server (DB)
- Identity framework (Auth)
- ErrorOr (Error handling)
- Fluent Validation (Model validation)
- Serilog (Logging)
- Mapperly (Mapping)

### Clean architecture separation:
- Domain layer includes:
   - Wand entity on which all standard CRUD operations are performed;
   - AppUser entity which is used for identity
   - Domain errors related to actions on entities;
- Application layer includes:
   - All CQRS stuff related to wands and authentication;
   - Application errors related to data access and etities validation;
   - Behaviors for general logging and model validation;
   - Custom validators for models;
   - Interfaces of services;
- Infrastructure layer includes:
   - All persistence related stuff:
      - Repository
      - DbContexts
      - Migrations
   - Implementation of JWT generation and configuration
- Presentation layer inсludes:
   - DTO's;
   - Mapping logic;
   - Swagger configuration
   - Controllers:
      - Errors controller for unexpected problems;
      - Base controller for overridden logic
      - Wands controller for CRUD operations
      - Auth-controller for registration and login

Each layer contains its own DependencyInjection file with registration and configuration of all related services.
  
