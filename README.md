# Student Attendance Tracking App

Student Attendance Tracking App is an educational project that aims to use many design patterns and packages effectively as an ASP.NET Core Web API (.NET 8) project. The latest version of ASP.NET Core packages and current libraries were used. It was built with N-Tier Architecture. The aim of the project is to create a list of the courses that students are or are not attending.

## Table Of Contents
- [Things to do before starting the program]()
- [Project Layers](https://github.com/tugcetorunn/StudentAttendanceTrackingApp/tree/master?tab=readme-ov-file#project-layers)
- [The Technologies Used](https://github.com/tugcetorunn/StudentAttendanceTrackingApp/tree/master?tab=readme-ov-file#the-technologies-used-are-as-follows)
  - [In the Presentation Layer](https://github.com/tugcetorunn/StudentAttendanceTrackingApp/tree/master?tab=readme-ov-file#in-the-presentation-layer)
  - [In the Business Layer](https://github.com/tugcetorunn/StudentAttendanceTrackingApp/tree/master?tab=readme-ov-file#in-the-business-layer)
  - [In the Data Layer](https://github.com/tugcetorunn/StudentAttendanceTrackingApp/tree/master?tab=readme-ov-file#in-the-data-layer)

## Things to do before starting the program
- Postgresql must be installed.
- The migrations file in the data layer must be deleted. (Otherwise, when you run the update-database command, the contents of that file will also try to be loaded into the database, and the program will probably give an error.)
- The connection string must be edited according to your own information (server).
- A schema with the same name as the search path value we wrote in the connection string (in this project, "satapp") must be created manually via Postgresql.
- The seed data is automatically created when the on model creating method is run.

## Project Layers

1) `Business` --> Repositories, Specifications, Validations, Token Validation, Commands, Queries, Handlers
2) `Data` --> Context, Entities, Configurations, Extensions, Migrations
3) `Presentation` --> Controllers, Common, Extensions

## The technologies used are as follows:
### In the Presentation layer;
#### .NET Core Web Api
It was used to get the ready api project folder structure.
#### Swashbuckle.AspNetCore
It is for Swagger UI integration.
#### CorePackageAuthorization 
It was used to integrate into the project the generic dll project uploaded to local nuget packages. You can find it in my repo named TT.
#### System.IdentityModel.Tokens.Jwt 
It was used to generate and manage JWT tokens.
#### Microsoft.AspNetCore.Authentication.JwtBearer
It was used to authenticate with JWT tokens.
#### Microsoft.EntityFrameworkCore.Design
It was used to migrate data via Program.cs.
#### FluentValidation.AspNetCore
It was used to integrate into the project Fluent Validation library.
### In the Business layer;
#### CorePackageAuthorization
It was used to create business rules for JWT bearer.
#### MediatR - CQRS
`CQRS` design pattern was used to separate crud operations according to whether they manipulate the database or not, thus providing faster output. As its name suggests, the `Mediator` pattern mediates the cqrs structure. It prevents controllers from establishing chaotic dependencies by communicating directly with handlers. The mediator knows which handlers will be called only when we send commands and queries with the "Send()" method it contains. MediatR design pattern cannot be used without CQRS structure.
#### Ardalis.Specification
It is used to define and manage query operations centrally with the specification design pattern. With this pattern we create reusable queries. This pattern allows for better testing of our queries. It also allows creating a more abstract layer with the repository design pattern.
#### Ardalis.Specification.EntityFrameworkCore
It allows integration of Ardalis.Specification with EF Core. This integration allows us to use the Specification in data access layers that work with EF Core.
#### FluentValidation
It is for validation of requests received from the user for create and update commands.
#### Microsoft.AspNetCore.Http.Abstractions
It was used to get the JWT token in the "Authorization" header from the incoming HTTP request for validation.
### In the Data layer;
#### Npgsql.EntityFrameworkCore.PostgreSQL
It was used to connection for PostgreSQL.
#### Microsoft.EntityFrameworkCore
It was used to establish a connection to the database I created with code first, to define data models, to create queries and to perform database operations (basic ORM functions).
#### Microsoft.EntityFrameworkCore.Design
It was used to migrate data to postgresql.
#### Microsoft.EntityFrameworkCore.Tools
It was used to use command line tools (PMC, CLI...).
#### Microsoft.EntityFrameworkCore.Relational
It was used to create table names as desired in entity configuration classes.

