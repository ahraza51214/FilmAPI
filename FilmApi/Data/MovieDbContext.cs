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
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Character>()
                .HasMany(c => c.Movies)
                .WithMany(m => m.Characters)
                .UsingEntity(j => j.ToTable("CharacterMovie"));

            // Seeding data
            /// Franchises
            modelBuilder.Entity<Franchise>().HasData(
                new Franchise { Id = 1, Name = "Marvel Cinematic Universe", Description = "Marvel movies franchise" },
                new Franchise { Id = 2, Name = "Lord of the Rings", Description = "Fantasy movie franchise" }
                // Add more franchises here
            );
            /// Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Iron Man",
                    Genre = "Action, Adventure",
                    ReleaseYear = 2008,
                    Director = "Jon Favreau",
                    FranchiseId = 1
                }
                // Add more movies here
            );
            /// Characters
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, FullName = "Tony Stark", Gender = "Male", Alias = "Iron Man", PictureUrl = "URL" }
                // Add more characters here
            );
        }
    }
}