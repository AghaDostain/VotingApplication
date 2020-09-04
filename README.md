# VotingApplication

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

### Prerequisites

What things you need to install the software and how to install them

```
Microsoft Visual Studio 2019 or above
Dot Net Core 3.1 
Microsoft SQL Server Management Studio 2018
```

### Installing

A step by step series of examples that tell you how to get a development env running

```
1. Clone this repository in your local machine.
2. Create an empty database in MS SQL with the name "Voting".
3. Open the solution in Visual Studio.
4. Compare the Database project with the newly created empty database.
5. Update the empty Database with the provided schema in the Database project.
6. In the database project open the scripts folder and navigate to the post-deployment folder where you would find the seed.sql file run the file manually in the database. 
7. Update the database connection string in the WebAPI project appsettings.json file.
8. Run Unit Test from VotingApp.Repositories.Test / VotingApp.Services.Test project to verify that your local database is up and running.
9. If test results are all good then run the project and it will pop up the Swagger UI page.
```

## Built With

* [ASP.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.0) - The API framework used
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - Microsoft ORM
* [Swagger](https://swagger.io/) - API building and testing
* [Fluent Validation](https://fluentvalidation.net/) - Validations
* [AutoRegisterDI](https://github.com/JonPSmith/NetCore.AutoRegisterDi) - Auto Registering Dependency Injection
