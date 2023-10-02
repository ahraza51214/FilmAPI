# FilmAPI
Noroff BackEnd Assignment 3

## AUTHORS:
* Ali Hassan Raza (ahraza.devOps@gmail.com)
* Pau Go Si (paugosi@hotmail.com)

## Summarize:
The goal of this assignment is to create a Web API and document it by using Entity Framework Code First workflow and an ASP.NET Core Web API in C#. 

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

Lastly, in Visual Studio choose: **Tool**->**Nuget Package Manager**->**Package Manager Console** and type:
```
add-migration IntitialDB
```
and then:
```
update-database
```
<br>
By follow the above guidlines, you will now be able to run our Web Film API on your local machine.


## ER Class Diagram:
<img width="1100" alt="MovieDbERDiagram" src="(https://github.com/ahraza51214/FilmAPI/assets/38948071/5371c4f5-00da-4b2c-9017-2f7ceaad7feb)">
