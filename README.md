# Wand's Shop API
API project with clean architecture separation and СQRS:
- Domain layer includes:
   - Wand entity on which all standard CRUD operations are performed;
   - Domain errors related to actions on wands;
- Application layer includes:
   - All CQRS stuff related to wands;
   - Application errors related to data access;
   - Behaviors for general logging and model validation;
   - Custom validators for models;
   - Interfaces of services;
- Infrastructure layer includes:
   - All persistence related stuff:
      - Repository
      - DbContext
      - Migrations
- Presentation layer inсludes:
   - DTO's;
   - Mapping logic;
   - Controllers:
      - Errors controller for unexpected problems;
      - Base controller for overridden logic
      - Wands controller for CRUD operations

Each layer contains its own DependencyInjection file with registration of all related services.
  
