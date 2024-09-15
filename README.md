# Student Attendance Tracking App

Student Attendance Tracking App is an educational project that aims to use many design patterns and packages effectively as an ASP.NET Core Web API (.NET 8) project. The latest version of ASP.NET Core packages and current libraries were used. It was built with N-Tier Architecture. The aim of the project is to create a list of the courses that students are or are not attending.

## Table Of Contents
- [Project Layers]()
- [The Technologies Used]()
  - [In the Presentation Layer]()
  - [In the Business Layer]()
  - [In the Data Layer]()

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
`CQRS` design pattern was used to separate crud operations according to whether they manipulate the database or not, thus providing faster output. As its name suggests, the `Mediator` pattern mediates the cqrs structure. It prevents controllers from establishing chaotic dependencies by communicating directly with handlers. The mediator knows which handlers will be called only when we send commands and queries with the "Send()" method it contains.
#### Ardalis.Specification
It is used to define and manage query operations centrally with the specification design pattern. It also allows creating a more abstract layer with the repository design pattern.
#### Ardalis.Specification.EntityFrameworkCore
It provides integration with Entity Framework Core, thus providing direct access to specification and repository classes.
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
