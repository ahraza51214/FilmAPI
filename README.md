# FilmAPI
Noroff BackEnd Assignment 3

## AUTHORS:
* Ali Hassan Raza (Ahraza.DevOps@gmail.com)
* Pau Go Si (Paugosi@hotmail.com)

## Summarize:
The goal of this assignment is to create and document a Web API using Entity Framework Code First workflow and ASP.NET Core Web API in C#. 

## Set up the development environment:
Make sure you have installed at least the following tools:
* Visual Studio 2022 with .NET 6.
* SQL Server Management Studio 2019

Further, make sure you have these packages installed in Visual Studio (rightclick on the project file named FilmApi and click 'Manage Nuget Packages...'):
* AutoMapper.Extensions.Microsoft.DependencyInjection
* Microsoft.AspNetCore.OpenApi
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.Sqlite
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools
* Microsoft.VisualStudio.Web.CodeGeneration.Design
* Swashbuckle.AspNetCore

Then in the file named appsettings.json contains a "ConnectionStrings" that looks like:
```
"ConnectionStrings": {
...
  "Guest": ""
}
```
Please provide your database parameters in the ConnectionStrings to establish connection to your database.
Also remember to insert 'Guest' in the Program.cs such that it looks like:
```
// Add EF
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Guest")));
```

Lastly, remember to delete the 'Migrations' folder, then in Visual Studio choose: **Tool**->**Nuget Package Manager**->**Package Manager Console** and type:
```
add-migration IntitialDB
```
and then:
```
update-database
```
<br>
By following the above guidlines, you will now be able to run our Web Film API on your local machine.


## ER Class Diagram:
<img width="1000" alt="MovieDbERDiagram" src="https://github.com/ahraza51214/FilmAPI/assets/38948071/5371c4f5-00da-4b2c-9017-2f7ceaad7feb">

## Code Structure:
In our project we have following folders:

Entities folder: Classes in the entities folder represents the tables in the 'MovieDb' database.

DTOs folder: DTOs (data transfer objects) folder. Contains objects we utilize to present only the essential information to the client regarding a request call.

Mappers folder: In the 'Mappers' folder we define mapping profiles for characters, franchises, and movies.

Services Folder: The 'Services' folder contains service classes for franchise, movies and characters, which take care of communication with the database depending on what request call the user makes to the API.

Controllers folder: In the 'Controllers' folder we outline our controllers for franchises, movies, and characters. These controllers communicate with our services through the service facade.

OBS! Our project also has ServiceFacade.cs file which is an facade to all the services we have in our project.

