# Domain-Driven-Design-DDD--Base-Tamplete


putting domain events into a CQRS application and  use the MediatR.


I currently have the MediatR and MediatR .net Core DI packages installed in the UI project and they are added to DI using .AddMediatR()


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
    ![1_YVxaXqiIYskqPauNKZ2OSA](https://user-images.githubusercontent.com/34911292/80547828-dc8ad180-89c1-11ea-9b11-2ade3c6064a6.png)
