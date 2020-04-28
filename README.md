# Domain-Driven-Design-DDD--Base-Tamplete

I'm just getting started with DDD. 
I'm putting domain events into a CQRS application and I'm stumbling on a fundamental task: How to use the MediatR.
INotification marker interface within the domain project without creating a domain dependency on infrastructure.

I currently have the MediatR and MediatR .net Core DI packages installed in the UI project and they are added to DI using .AddMediatR(), with the command


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
