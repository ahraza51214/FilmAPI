using FilmApi.Data;
using FilmApi.Services;
using FilmApi.Services.CharacterService;
using FilmApi.Services.FranchiseService;
using FilmApi.Services.MovieService;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.OpenApi.Models;


internal class Program
{
    private static void Main(string[] args)
    {
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

        // Adding Swagger Documentation
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Postgrad API",
                Description = "Film API serves as a platform for storing and managing movie-related data. " +
                "Utilizing ASP.NET Core with Entity Framework Core and SQL Server, " +
                "the API encapsulates functionalities for movies, characters, and franchises. It allows users to: \n\n" +

                    "- **Maintain Characters**: " +
                        "Store basic information such as name, alias, gender, and an associated image URL for each character. \n\n" +

                    "- **Catalog Movies**: Organize movies with essential details including title, genre, release year, " +
                        "director, poster image, and trailer link. \n\n" +

                    "- **Organize Franchises**: Manage franchises, each potentially encompassing multiple movies, " +
                        "with an associated description. \n\n" +

                "Key API functionalities: \n\n" +

                    "- **CRUD Operations**: Full Create, Read, Update, and Delete functionalities for movies, " +
                        "characters, and franchises. \n\n" +

                    "- **Relational Updates**: Specifically tailored endpoints for updating character associations " +
                        "in movies and movie associations in franchises. \n\n" +

                    "- **Reporting**: Generate reports to fetch movies in a franchise, characters in a movie, " +
                        "and characters within a particular franchise. \n\n" +

                "This API uses DTOs to ensure a decoupled client experience and to safeguard against over - posting. " +
                "It also ensures documentation clarity through Swagger / OpenAPI annotations. \n\n" +

                "**Note**: Ensure to adhere to the documentation when interacting with the endpoints and follow the business rules to maintain the integrity of the data relationships."
                /*,
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "ME",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                Name = "Example License",
                Url = new Uri("https://example.com/license")
            }*/
            });
            // using System.Reflection;
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        // Add EF
        builder.Services.AddDbContext<MovieDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Ali")));

        // Add automapper
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
    }
}