using System;
using FilmApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API configuration for relationships
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Franchise)
                .WithMany(f => f.Movies)
                .HasForeignKey(m => m.FranchiseId)
                // This part of the code handle the requirement of setting the FranchiseId in Movie to null
                // when a Franchise is deleted. 
                .OnDelete(DeleteBehavior.SetNull);

            //This only define the many-to-many relationship between Movie and Characters
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Characters)
                .WithMany(c => c.Movies)
                .UsingEntity(j => j.ToTable("CharacterMovie"));

            //Alternatively, we could allso had define the many-to-many relationship between Movie and Characters as
            /*
            modelBuilder.Entity<Character>()
                .HasMany(c => c.Movies)
                .WithMany(m => m.Characters)
                .UsingEntity(j => j.ToTable("CharacterMovie"));
            */


            // Seeding data
            /// Franchises data
            modelBuilder.Entity<Franchise>().HasData(
                new Franchise { Id = 1, Name = "Marvel Cinematic Universe", Description = "Marvel movies franchise" },
                new Franchise { Id = 2, Name = "Lord of the Rings", Description = "Fantasy movie franchise" },
                new Franchise { Id = 3, Name = "Star Wars", Description = "Epic space opera franchise" },
                new Franchise { Id = 4, Name = "Harry Potter", Description = "Fantasy book-to-film franchise" }
            );

            /// Movies data
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Iron Man",
                    Genre = "Action, Adventure",
                    ReleaseYear = 2008,
                    Director = "Jon Favreau",
                    PictureUrl = "URL1",
                    TrailerUrl = "TrailerURL1",
                    FranchiseId = 1
                },
                new Movie
                {
                    Id = 2,
                    Title = "The Avengers",
                    Genre = "Action, Adventure",
                    ReleaseYear = 2012,
                    Director = "Joss Whedon",
                    PictureUrl = "URL2",
                    TrailerUrl = "TrailerURL2",
                    FranchiseId = 1
                },
                new Movie
                {
                    Id = 3,
                    Title = "Guardians of the Galaxy",
                    Genre = "Action, Adventure",
                    ReleaseYear = 2014,
                    Director = "James Gunn",
                    PictureUrl = "URL3",
                    TrailerUrl = "TrailerURL3",
                    FranchiseId = 1
                },
                new Movie
                {
                    Id = 4,
                    Title = "The Fellowship of the Ring",
                    Genre = "Adventure, Fantasy",
                    ReleaseYear = 2001,
                    Director = "Peter Jackson",
                    PictureUrl = "URL4",
                    TrailerUrl = "TrailerURL4",
                    FranchiseId = 2
                },
                new Movie
                {
                    Id = 5,
                    Title = "The Two Towers",
                    Genre = "Adventure, Fantasy",
                    ReleaseYear = 2002,
                    Director = "Peter Jackson",
                    PictureUrl = "URL5",
                    TrailerUrl = "TrailerURL5",
                    FranchiseId = 2
                },
                new Movie
                {
                    Id = 6,
                    Title = "The Return of the King",
                    Genre = "Adventure, Fantasy",
                    ReleaseYear = 2003,
                    Director = "Peter Jackson",
                    PictureUrl = "URL6",
                    TrailerUrl = "TrailerURL6",
                    FranchiseId = 2
                },
                new Movie
                {
                    Id = 7,
                    Title = "Star Wars: A New Hope",
                    Genre = "Action, Adventure",
                    ReleaseYear = 1977,
                    Director = "George Lucas",
                    PictureUrl = "URL7",
                    TrailerUrl = "TrailerURL7",
                    FranchiseId = 3
                },
                new Movie
                {
                    Id = 8,
                    Title = "Star Wars: The Empire Strikes Back",
                    Genre = "Action, Adventure",
                    ReleaseYear = 1980,
                    Director = "Irvin Kershner",
                    PictureUrl = "URL8",
                    TrailerUrl = "TrailerURL8",
                    FranchiseId = 3
                },
                new Movie
                {
                    Id = 9,
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Genre = "Adventure, Fantasy",
                    ReleaseYear = 2001,
                    Director = "Chris Columbus",
                    PictureUrl = "URL9",
                    TrailerUrl = "TrailerURL9",
                    FranchiseId = 4
                },
                new Movie
                {
                    Id = 10,
                    Title = "Harry Potter and the Chamber of Secrets",
                    Genre = "Adventure, Fantasy",
                    ReleaseYear = 2002,
                    Director = "Chris Columbus",
                    PictureUrl = "URL10",
                    TrailerUrl = "TrailerURL10",
                    FranchiseId = 4
                }
            );

            /// Characters data
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, FullName = "Tony Stark", Gender = "Male", Alias = "Iron Man", PictureUrl = "URL1" },
                new Character { Id = 2, FullName = "Steve Rogers", Gender = "Male", Alias = "Captain America", PictureUrl = "URL2" },
                new Character { Id = 3, FullName = "Natasha Romanoff", Gender = "Female", Alias = "Black Widow", PictureUrl = "URL3" },
                new Character { Id = 4, FullName = "Bruce Banner", Gender = "Male", Alias = "The Hulk", PictureUrl = "URL4" },
                new Character { Id = 5, FullName = "Thor Odinson", Gender = "Male", Alias = "Thor", PictureUrl = "URL5" },
                new Character { Id = 6, FullName = "Peter Parker", Gender = "Male", Alias = "Spider-Man", PictureUrl = "URL6" },
                new Character { Id = 7, FullName = "Diana Prince", Gender = "Female", Alias = "Wonder Woman", PictureUrl = "URL7" },
                new Character { Id = 8, FullName = "Bruce Wayne", Gender = "Male", Alias = "Batman", PictureUrl = "URL8" },
                new Character { Id = 9, FullName = "Clark Kent", Gender = "Male", Alias = "Superman", PictureUrl = "URL9" },
                new Character { Id = 10, FullName = "Leia Organa", Gender = "Female", Alias = "Princess Leia", PictureUrl = "URL10" },
                new Character { Id = 11, FullName = "Luke Skywalker", Gender = "Male", Alias = "Luke Skywalker", PictureUrl = "URL11" },
                new Character { Id = 12, FullName = "Harry Potter", Gender = "Male", Alias = "Harry Potter", PictureUrl = "URL12" },
                new Character { Id = 13, FullName = "Hermione Granger", Gender = "Female", Alias = "Hermione Granger", PictureUrl = "URL13" },
                new Character { Id = 14, FullName = "Ron Weasley", Gender = "Male", Alias = "Ron Weasley", PictureUrl = "URL14" }
            );

            // Associate characters with movies using Dictionary<string, object>
            modelBuilder.Entity<Character>()
                .HasMany(c => c.Movies)
                .WithMany(m => m.Characters)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterMovie",
                    l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    r => r.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    je =>
                    {
                        je.HasKey("CharacterId", "MovieId");
                        je.HasData(
                            new { CharacterId = 1, MovieId = 1 },  // Tony Stark (Iron Man)
                            new { CharacterId = 1, MovieId = 2 },  // Tony Stark (The Avengers)
                            new { CharacterId = 2, MovieId = 2 },  // Steve Rogers (The Avengers)
                            new { CharacterId = 2, MovieId = 3 },  // Steve Rogers (Guardians of the Galaxy)
                            new { CharacterId = 3, MovieId = 3 },  // Natasha Romanoff (Guardians of the Galaxy)
                            new { CharacterId = 3, MovieId = 4 },  // Natasha Romanoff (The Fellowship of the Ring)
                            new { CharacterId = 4, MovieId = 4 },  // Bruce Banner (The Fellowship of the Ring)
                            new { CharacterId = 4, MovieId = 5 },  // Bruce Banner (The Two Towers)
                            new { CharacterId = 5, MovieId = 5 },  // Thor Odinson (The Two Towers)
                            new { CharacterId = 5, MovieId = 6 },  // Thor Odinson (The Return of the King)
                            new { CharacterId = 6, MovieId = 7 },  // Peter Parker (Star Wars: A New Hope)
                            new { CharacterId = 7, MovieId = 7 },  // Diana Prince (Star Wars: A New Hope)
                            new { CharacterId = 7, MovieId = 8 },  // Diana Prince (Star Wars: The Empire Strikes Back)
                            new { CharacterId = 8, MovieId = 8 },  // Bruce Wayne (Star Wars: The Empire Strikes Back)
                            new { CharacterId = 8, MovieId = 9 },  // Bruce Wayne (Harry Potter and the Sorcerer's Stone)
                            new { CharacterId = 9, MovieId = 9 },  // Clark Kent (Harry Potter and the Sorcerer's Stone)
                            new { CharacterId = 9, MovieId = 10 }, // Clark Kent (Harry Potter and the Chamber of Secrets)
                            new { CharacterId = 10, MovieId = 10 }, // Leia Organa (Harry Potter and the Chamber of Secrets)
                            new { CharacterId = 11, MovieId = 10 }  // Luke Skywalker (Harry Potter and the Chamber of Secrets)
                            // Add more associations...
                        );
                    });
        }
    }
}