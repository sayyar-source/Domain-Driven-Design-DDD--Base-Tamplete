# Domain-Driven-Design-DDD--Base-Tamplete


putting domain events into a CQRS application and  use the MediatR.

Technologies implemented:

    - ASP.NET Core 3.1 (with .NET Core 3.1)
    - ASP.NET MVC Core
    - ASP.NET WebApi Core with JWT Bearer Authentication
	- ASP.NET Identity Core
    - Entity Framework Core 3.1
    - AutoMapper
	- FluentValidator
	- MediatR
    - Swagger UI with JWT support
    - Aggregate 
	- Value Objects 
	- Logging Behavior
	- Validation Behavior
	- Hi-lo
	- Specification Pattern
	- Entities Invariants
	- Operation-result


Architecture::

    - Full architecture with responsibility separation concerns, SOLID and Clean Code
	- Domain Driven Design (Layers and Domain Model Pattern)
	- Domain Events
	- Domain Notification
	- CQRS (Imediate Consistency)
	- Event Sourcing
	- Unit of Work
	- Repository and Generic Repository
	
	
My solution is organized in four projects as follows:

MyApp.Domain

    - Domain events
    - Aggregates
    - Interfaces (IRepository, etc), etc.
    
MyApp.ApplicationServices

    - Commands
    - Command Handlers, etc.
    
MyApp.Infrastructure

    - Repository 
    - Emailer, etc.
    
    
MyApp.Web

    - Startup
    - MediatR NuGet packages and DI here
    - UI, etc.
   
