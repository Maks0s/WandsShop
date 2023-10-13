# Wand's Shop API
### ASP.NET Core web API project with features of:
- Clean architecture
- CQRS
- All default CRUD operations
- Database integration
- JWT authentication
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

### Endpoints
![image](https://github.com/Maks0s/WandsShop/assets/89703990/544528c7-79ce-423c-afe4-22ba1bfc31c0)

### Schemas
![image](https://github.com/Maks0s/WandsShop/assets/89703990/913e1144-3845-43aa-9260-92948cc50e92)


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
  
