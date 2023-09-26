using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.CharacterId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "PictureUrl" },
                values: new object[,]
                {
                    { 1, "Iron Man", "Tony Stark", "Male", "URL1" },
                    { 2, "Captain America", "Steve Rogers", "Male", "URL2" },
                    { 3, "Black Widow", "Natasha Romanoff", "Female", "URL3" },
                    { 4, "The Hulk", "Bruce Banner", "Male", "URL4" },
                    { 5, "Thor", "Thor Odinson", "Male", "URL5" },
                    { 6, "Spider-Man", "Peter Parker", "Male", "URL6" },
                    { 7, "Wonder Woman", "Diana Prince", "Female", "URL7" },
                    { 8, "Batman", "Bruce Wayne", "Male", "URL8" },
                    { 9, "Superman", "Clark Kent", "Male", "URL9" },
                    { 10, "Princess Leia", "Leia Organa", "Female", "URL10" },
                    { 11, "Luke Skywalker", "Luke Skywalker", "Male", "URL11" },
                    { 12, "Harry Potter", "Harry Potter", "Male", "URL12" },
                    { 13, "Hermione Granger", "Hermione Granger", "Female", "URL13" },
                    { 14, "Ron Weasley", "Ron Weasley", "Male", "URL14" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Marvel movies franchise", "Marvel Cinematic Universe" },
                    { 2, "Fantasy movie franchise", "Lord of the Rings" },
                    { 3, "Epic space opera franchise", "Star Wars" },
                    { 4, "Fantasy book-to-film franchise", "Harry Potter" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "PictureUrl", "ReleaseYear", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { 1, "Jon Favreau", 1, "Action, Adventure", "URL1", 2008, "Iron Man", "TrailerURL1" },
                    { 2, "Joss Whedon", 1, "Action, Adventure", "URL2", 2012, "The Avengers", "TrailerURL2" },
                    { 3, "James Gunn", 1, "Action, Adventure", "URL3", 2014, "Guardians of the Galaxy", "TrailerURL3" },
                    { 4, "Peter Jackson", 2, "Adventure, Fantasy", "URL4", 2001, "The Fellowship of the Ring", "TrailerURL4" },
                    { 5, "Peter Jackson", 2, "Adventure, Fantasy", "URL5", 2002, "The Two Towers", "TrailerURL5" },
                    { 6, "Peter Jackson", 2, "Adventure, Fantasy", "URL6", 2003, "The Return of the King", "TrailerURL6" },
                    { 7, "George Lucas", 3, "Action, Adventure", "URL7", 1977, "Star Wars: A New Hope", "TrailerURL7" },
                    { 8, "Irvin Kershner", 3, "Action, Adventure", "URL8", 1980, "Star Wars: The Empire Strikes Back", "TrailerURL8" },
                    { 9, "Chris Columbus", 4, "Adventure, Fantasy", "URL9", 2001, "Harry Potter and the Sorcerer's Stone", "TrailerURL9" },
                    { 10, "Chris Columbus", 4, "Adventure, Fantasy", "URL10", 2002, "Harry Potter and the Chamber of Secrets", "TrailerURL10" }
                });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 4 },
                    { 4, 5 },
                    { 5, 5 },
                    { 5, 6 },
                    { 6, 7 },
                    { 7, 7 },
                    { 7, 8 },
                    { 8, 8 },
                    { 8, 9 },
                    { 9, 9 },
                    { 9, 10 },
                    { 10, 10 },
                    { 11, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_MovieId",
                table: "CharacterMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FranchiseId",
                table: "Movies",
                column: "FranchiseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Franchises");
        }
    }
}
