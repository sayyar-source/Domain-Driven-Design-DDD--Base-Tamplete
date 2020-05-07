# Domain-Driven-Design-DDD--Base-Tamplete


putting domain events into a CQRS application and  use the MediatR.


I currently have the MediatR and MediatR .net Core DI packages installed in the UI project and they are added to DI using .AddMediatR()

Technologies implemented:

ASP.NET Core 3.1 (with .NET Core 3.1)

ASP.NET MVC Core

ASP.NET WebApi Core with JWT Bearer Authentication

ASP.NET Identity Core

Entity Framework Core 3.1

.NET Core Native DI

AutoMapper

FluentValidator

MediatR

Swagger UI with JWT support

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
   
