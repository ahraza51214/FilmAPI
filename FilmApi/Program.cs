﻿using FilmApi.Data;
using FilmApi.Services;
using FilmApi.Services.CharacterService;
using FilmApi.Services.FranchiseService;
using FilmApi.Services.MovieService;
using Microsoft.EntityFrameworkCore;

using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register Services and ServiceFacade
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IFranchiseService, FranchiseService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ServiceFacade>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


// Add EF
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pau")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();