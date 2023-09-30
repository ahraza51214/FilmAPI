﻿// <auto-generated />
using System;
using FilmApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FilmApi.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("CharacterMovie", (string)null);

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            MovieId = 1
                        },
                        new
                        {
                            CharacterId = 1,
                            MovieId = 2
                        },
                        new
                        {
                            CharacterId = 2,
                            MovieId = 2
                        },
                        new
                        {
                            CharacterId = 2,
                            MovieId = 3
                        },
                        new
                        {
                            CharacterId = 3,
                            MovieId = 3
                        },
                        new
                        {
                            CharacterId = 3,
                            MovieId = 4
                        },
                        new
                        {
                            CharacterId = 4,
                            MovieId = 4
                        },
                        new
                        {
                            CharacterId = 4,
                            MovieId = 5
                        },
                        new
                        {
                            CharacterId = 5,
                            MovieId = 5
                        },
                        new
                        {
                            CharacterId = 5,
                            MovieId = 6
                        },
                        new
                        {
                            CharacterId = 6,
                            MovieId = 7
                        },
                        new
                        {
                            CharacterId = 7,
                            MovieId = 7
                        },
                        new
                        {
                            CharacterId = 7,
                            MovieId = 8
                        },
                        new
                        {
                            CharacterId = 8,
                            MovieId = 8
                        },
                        new
                        {
                            CharacterId = 8,
                            MovieId = 9
                        },
                        new
                        {
                            CharacterId = 9,
                            MovieId = 9
                        },
                        new
                        {
                            CharacterId = 9,
                            MovieId = 10
                        },
                        new
                        {
                            CharacterId = 10,
                            MovieId = 10
                        },
                        new
                        {
                            CharacterId = 11,
                            MovieId = 10
                        });
                });

            modelBuilder.Entity("FilmApi.Data.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "Iron Man",
                            FullName = "Tony Stark",
                            Gender = "Male",
                            PictureUrl = "URL1"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "Captain America",
                            FullName = "Steve Rogers",
                            Gender = "Male",
                            PictureUrl = "URL2"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "Black Widow",
                            FullName = "Natasha Romanoff",
                            Gender = "Female",
                            PictureUrl = "URL3"
                        },
                        new
                        {
                            Id = 4,
                            Alias = "The Hulk",
                            FullName = "Bruce Banner",
                            Gender = "Male",
                            PictureUrl = "URL4"
                        },
                        new
                        {
                            Id = 5,
                            Alias = "Thor",
                            FullName = "Thor Odinson",
                            Gender = "Male",
                            PictureUrl = "URL5"
                        },
                        new
                        {
                            Id = 6,
                            Alias = "Spider-Man",
                            FullName = "Peter Parker",
                            Gender = "Male",
                            PictureUrl = "URL6"
                        },
                        new
                        {
                            Id = 7,
                            Alias = "Wonder Woman",
                            FullName = "Diana Prince",
                            Gender = "Female",
                            PictureUrl = "URL7"
                        },
                        new
                        {
                            Id = 8,
                            Alias = "Batman",
                            FullName = "Bruce Wayne",
                            Gender = "Male",
                            PictureUrl = "URL8"
                        },
                        new
                        {
                            Id = 9,
                            Alias = "Superman",
                            FullName = "Clark Kent",
                            Gender = "Male",
                            PictureUrl = "URL9"
                        },
                        new
                        {
                            Id = 10,
                            Alias = "Princess Leia",
                            FullName = "Leia Organa",
                            Gender = "Female",
                            PictureUrl = "URL10"
                        },
                        new
                        {
                            Id = 11,
                            Alias = "Luke Skywalker",
                            FullName = "Luke Skywalker",
                            Gender = "Male",
                            PictureUrl = "URL11"
                        },
                        new
                        {
                            Id = 12,
                            Alias = "Harry Potter",
                            FullName = "Harry Potter",
                            Gender = "Male",
                            PictureUrl = "URL12"
                        },
                        new
                        {
                            Id = 13,
                            Alias = "Hermione Granger",
                            FullName = "Hermione Granger",
                            Gender = "Female",
                            PictureUrl = "URL13"
                        },
                        new
                        {
                            Id = 14,
                            Alias = "Ron Weasley",
                            FullName = "Ron Weasley",
                            Gender = "Male",
                            PictureUrl = "URL14"
                        });
                });

            modelBuilder.Entity("FilmApi.Data.Entities.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Franchises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Marvel movies franchise",
                            Name = "Marvel Cinematic Universe"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Fantasy movie franchise",
                            Name = "Lord of the Rings"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Epic space opera franchise",
                            Name = "Star Wars"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Fantasy book-to-film franchise",
                            Name = "Harry Potter"
                        });
                });

            modelBuilder.Entity("FilmApi.Data.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TrailerUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Jon Favreau",
                            FranchiseId = 1,
                            Genre = "Action, Adventure",
                            PictureUrl = "URL1",
                            ReleaseYear = 2008,
                            Title = "Iron Man",
                            TrailerUrl = "TrailerURL1"
                        },
                        new
                        {
                            Id = 2,
                            Director = "Joss Whedon",
                            FranchiseId = 1,
                            Genre = "Action, Adventure",
                            PictureUrl = "URL2",
                            ReleaseYear = 2012,
                            Title = "The Avengers",
                            TrailerUrl = "TrailerURL2"
                        },
                        new
                        {
                            Id = 3,
                            Director = "James Gunn",
                            FranchiseId = 1,
                            Genre = "Action, Adventure",
                            PictureUrl = "URL3",
                            ReleaseYear = 2014,
                            Title = "Guardians of the Galaxy",
                            TrailerUrl = "TrailerURL3"
                        },
                        new
                        {
                            Id = 4,
                            Director = "Peter Jackson",
                            FranchiseId = 2,
                            Genre = "Adventure, Fantasy",
                            PictureUrl = "URL4",
                            ReleaseYear = 2001,
                            Title = "The Fellowship of the Ring",
                            TrailerUrl = "TrailerURL4"
                        },
                        new
                        {
                            Id = 5,
                            Director = "Peter Jackson",
                            FranchiseId = 2,
                            Genre = "Adventure, Fantasy",
                            PictureUrl = "URL5",
                            ReleaseYear = 2002,
                            Title = "The Two Towers",
                            TrailerUrl = "TrailerURL5"
                        },
                        new
                        {
                            Id = 6,
                            Director = "Peter Jackson",
                            FranchiseId = 2,
                            Genre = "Adventure, Fantasy",
                            PictureUrl = "URL6",
                            ReleaseYear = 2003,
                            Title = "The Return of the King",
                            TrailerUrl = "TrailerURL6"
                        },
                        new
                        {
                            Id = 7,
                            Director = "George Lucas",
                            FranchiseId = 3,
                            Genre = "Action, Adventure",
                            PictureUrl = "URL7",
                            ReleaseYear = 1977,
                            Title = "Star Wars: A New Hope",
                            TrailerUrl = "TrailerURL7"
                        },
                        new
                        {
                            Id = 8,
                            Director = "Irvin Kershner",
                            FranchiseId = 3,
                            Genre = "Action, Adventure",
                            PictureUrl = "URL8",
                            ReleaseYear = 1980,
                            Title = "Star Wars: The Empire Strikes Back",
                            TrailerUrl = "TrailerURL8"
                        },
                        new
                        {
                            Id = 9,
                            Director = "Chris Columbus",
                            FranchiseId = 4,
                            Genre = "Adventure, Fantasy",
                            PictureUrl = "URL9",
                            ReleaseYear = 2001,
                            Title = "Harry Potter and the Sorcerer's Stone",
                            TrailerUrl = "TrailerURL9"
                        },
                        new
                        {
                            Id = 10,
                            Director = "Chris Columbus",
                            FranchiseId = 4,
                            Genre = "Adventure, Fantasy",
                            PictureUrl = "URL10",
                            ReleaseYear = 2002,
                            Title = "Harry Potter and the Chamber of Secrets",
                            TrailerUrl = "TrailerURL10"
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("FilmApi.Data.Entities.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FilmApi.Data.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FilmApi.Data.Entities.Movie", b =>
                {
                    b.HasOne("FilmApi.Data.Entities.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("FilmApi.Data.Entities.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
